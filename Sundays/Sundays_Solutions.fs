#if INTERACTIVE
#else
namespace FSharpExercises
#endif

module DaysSolution = 

   open System

   let Sundays (startDate : DateTime) =
      let endDate = startDate.AddYears(1).AddDays(-1.)
      let dayCount = (endDate - startDate).TotalDays |> int
      [|
         for d in 0..dayCount-1 do
            let date = startDate.AddDays(float(d)).Date
            if date.DayOfWeek = System.DayOfWeek.Sunday then
               yield date
      |]

   let SundaysNoLoop (startDate : DateTime) =
      let endDate = startDate.AddYears(1).AddDays(-1.)
      let dayCount = (endDate - startDate).TotalDays |> int
      Array.init dayCount (fun dayNum -> startDate.AddDays(dayNum |> double))
      |> Array.filter (fun date -> date.DayOfWeek = System.DayOfWeek.Sunday)

   let DayOfWeekInNextYear (startDate : DateTime) (dayOfWeek : System.DayOfWeek) =
      let endDate = startDate.AddYears(1).AddDays(-1.)
      let dayCount = (endDate - startDate).TotalDays |> int
      Array.init dayCount (fun dayNum -> startDate.AddDays(dayNum |> double))
      |> Array.filter (fun date -> date.DayOfWeek = dayOfWeek)

module DaysSolutionTests =

   open System
   open NUnit.Framework
   open FsUnit
   open DaysSolution

   [<TestCase("2015-01-01", 52, Description="An ordinary year starting 1st Jan")>]
   [<TestCase("2015-02-28", 52, Description="An ordinary year starting 28th Feb")>]
   [<TestCase("2016-02-28", 53, Description="A leap year starting 28th Feb")>]
   [<TestCase("2016-02-29", 52, Description="A leap year starting 29th Feb")>]
   [<TestCase("2015-01-04", 52, Description="An ordinary year starting on a Sunday")>]
   // What other cases could you add?
   let ``The number of Sundays is calculated correctly``(startDateStr, expected) =
      let startDate = DateTime.Parse startDateStr
      let actual = Sundays startDate |> Array.length
      actual |> should equal expected

   [<TestCase("2015-01-01", 52, Description="An ordinary year starting 1st Jan")>]
   [<TestCase("2015-02-28", 52, Description="An ordinary year starting 28th Feb")>]
   [<TestCase("2016-02-28", 53, Description="A leap year starting 28th Feb")>]
   [<TestCase("2016-02-29", 52, Description="A leap year starting 29th Feb")>]
   [<TestCase("2015-01-04", 52, Description="An ordinary year starting on a Sunday")>]
   // What other cases could you add?
   let ``The number of Sundays is calculated correctly (noloop version)``(startDateStr, expected) =
      let startDate = DateTime.Parse startDateStr
      let actual = SundaysNoLoop startDate |> Array.length
      actual |> should equal expected

   [<TestCase("2015-01-01", 52, Description="An ordinary year starting 1st Jan")>]
   [<TestCase("2015-02-28", 52, Description="An ordinary year starting 28th Feb")>]
   [<TestCase("2016-02-28", 53, Description="A leap year starting 28th Feb")>]
   [<TestCase("2016-02-29", 52, Description="A leap year starting 29th Feb")>]
   [<TestCase("2015-01-04", 52, Description="An ordinary year starting on a Sunday")>]
   // What other cases could you add?
   let ``The number of Sundays is calculated correctly (dayOfWeek version)``(startDateStr, expected) =
      let startDate = DateTime.Parse startDateStr
      let actual = DayOfWeekInNextYear startDate DayOfWeek.Sunday |> Array.length
      actual |> should equal expected

   [<TestCase("2015-01-01", 52, Description="An ordinary year starting 1st Jan")>]
   [<TestCase("2015-02-28", 52, Description="An ordinary year starting 28th Feb")>]
   [<TestCase("2016-02-28", 52, Description="A leap year starting 28th Feb")>]
   [<TestCase("2016-02-29", 52, Description="A leap year starting 29th Feb")>]
   [<TestCase("2015-01-04", 52, Description="An ordinary year starting on a Sunday")>]
   // What other cases could you add?
   let ``The number of Mondays is calculated correctly (dayOfWeek version)``(startDateStr, expected) =
      let startDate = DateTime.Parse startDateStr
      let actual = DayOfWeekInNextYear startDate DayOfWeek.Monday |> Array.length
      actual |> should equal expected