#if INTERACTIVE
#else
namespace FSharpExercises
#endif

module Days = 

   open System

   // How would you leap-year-proof this code?  It should return
   // the date of every Sunday in the next calendar year.  One
   // calendar year from 28/2/xxxx is defined as dates up to but
   // excluding 28/2/yyyy.  One calendar year from 29/2/xxxx (when 
   // xxxx is a leap year) is defined as dates up to but excluding
   // 28/2/yyyy.
   let Sundays =
      [|
         let startDate = System.DateTime.Now
         for d in 0..364 do
            let date = startDate.AddDays(float(d)).Date
            if date.DayOfWeek = System.DayOfWeek.Sunday then
               yield date
      |]

   // How would you refactor this code (start with your leap-year 
   // proofed version) to use Array.init and Array.filter instead
   // of a comprehension.
   let SundaysNoLoop (startDate : DateTime) =
      ()

   // How would you generalize this code so that it takes a DayOfWeek
   // argument instead of hardwiring Sundays?
   let DayOfWeekInNextYear (startDate : DateTime) =
      ()