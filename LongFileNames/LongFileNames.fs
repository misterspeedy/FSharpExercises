#if INTERACTIVE
#else
namespace LongFileNames
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
      ()

   // 2) Amend the function from 1 to take the start path and wildcards as arguments
   let FileNamesByLength2() =
      ()

   // 3) Amend the function from 2 to also take an 'n' parameter and return the longest
   // n filenames.  Would you use Seq.take or Seq.truncate?  Why?
   let LongestFileNames() =
      ()

   // 4) When you try out function 3 using FSI, FSI only outputs the first few items
   // (as it will do with any sequence).  How would you inspect the results to show
   // that they were correct?

   // 5) Amend the function from 3 to return not the full paths of the files, but
   // a sequence of tuples.  The first item in each tuple should be the path without
   // the filename, and the second should be the filename without the path.
   let LongestFileNames2() =
      ()