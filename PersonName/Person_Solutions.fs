#if INTERACTIVE
#else
namespace PersonNameSolution
#endif

type Name = 
   { 
      First : string Option
      Middle : string Option
      Last : string Option
   }

module NameFormatting =

   let FormatName (name : Name) =
      match name.First, name.Middle, name.Last with
      // Last, middle and first populated: output is "LLLL, FFFF MMMM"
      | Some f, Some m, Some l -> sprintf "%s, %s %s" l f m
      // Last and either middle or first populated: output is "LLLL, XXXX" where XXXX is 
      // whichever of middle and first that is populated
      | Some x, None, Some l
      | None, Some x, Some l -> sprintf "%s, %s" l x
      // First and middle are populated but surname is not: output is "(No surname), FFFF MMMM
      | Some f, Some m, None -> sprintf "(No surname), %s %s" f m
      // Only one field populated: output is "XXXX" where "XXXX" is the content of the one populated field
      | Some s, None, None
      | None, Some s, None
      | None, None, Some s -> sprintf "%s" s // Actually this could just return s
      // All fields missing: output is "(Unknown)"
      | None, None, None -> "(Unknown)"

