#if INTERACTIVE
#else
namespace LongFileNamesSolutions
#endif

module FileNames =

   open System.IO

   /// This function lists filenames over 20 characters
   /// that are found below c:\program files.
   let LongFileNames() =
      Directory.EnumerateFiles(@"c:\Program Files", "*.*", SearchOption.AllDirectories)
      |> Seq.filter (fun path -> 
         let fileName = Path.GetFileNameWithoutExtension(path)
         fileName.Length > 20)

   // Exercises:
   //
   // 1) Make another function which returns all
   //    the filenames in c:\program files but in
   //    descending order of file name length.
   let FileNamesByLength() =
      Directory.EnumerateFiles(@"c:\Program Files", "*.*", SearchOption.AllDirectories)
      |> Seq.sortBy (fun path -> -path.Length)

   // 2) Amend the function from 1 to take the start path and wildcards as arguments
   let FileNamesByLength2 path pattern =
      Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories)
      |> Seq.sortBy (fun path -> -path.Length)

   // 3) Amend the function from 2 to also take an 'n' parameter and return the longest
   // n filenames.  Would you use Seq.take or Seq.truncate?  Why?
   let LongestFileNames path pattern count =
      Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories)
      |> Seq.sortBy (fun path -> -path.Length)
      // Use Seq.truncate not Seq.take in case the sequence
      // contains fewer than n elements.
      |> Seq.truncate count

   // 4) When you try out function 3 using FSI, FSI only outputs the first few items
   // (as it will do with any sequence).  How would you inspect the results to show
   // that they were correct?
   //
   // LongestFileNames @"c:\program files" "*.txt" 100 |> Seq.count;;
   // 
   // LongestFileNames @"c:\program files" "*.txt" 100 |> Seq.iter (printfn "%s");;

   // 5) Amend the function from 3 to return not the full paths of the files, but
   // a sequence of tuples.  The first item in each tuple should be the path without
   // the filename, and the second should be the filename without the path.
   let LongestFileNames2 path pattern count =
      Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories)
      |> Seq.sortBy (fun path -> -path.Length)
      |> Seq.truncate count
      |> Seq.map (fun path -> Path.GetDirectoryName(path), Path.GetFileName(path))
