#if INTERACTIVE
#else
namespace PersonName
#endif

// This is the person 'Name' record type from the presentation...
type Name = 
   { 
      First : string
      Middle : string Option
      Last : string 
   }

// ...and this function prints the name in a sensible format
module NameFormatting =

   let FormatName (name : Name) =
      match name.First, name.Middle, name.Last with
      | f, Some m, l -> sprintf "%s, %s %s" l f m
      | f, None, l -> sprintf "%s, %s" l f

// Exercises:

// 1) Alter the record type so that all of the fields are optional.
//
// 2) Note the effect this has on the FormatName function.
//
// 3) Edit FormatName so that it covers all the possible cases. The required output is now:
//
//    Last, middle and first populated: output is "LLLL, FFFF MMMM"
//
//    Last and either middle or first populated: output is "LLLL, XXXX" where XXXX is 
//     whichever of middle and first that is populated
//
//    First and middle are populated but surname is not: output is "(No surname), FFFF MMMM
//
//    Only one field populated: output is "XXXX" where "XXXX" is the content of the one populated field
//    All fields missing: output is "(Unknown)"
//
