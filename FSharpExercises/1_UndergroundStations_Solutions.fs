#if INTERACTIVE
#else
namespace FSharpExercises
#endif

module UndergroundSolutions = 

   // You can 'open' a module like a namspace:
   open Underground
   
   // Which stations contain "East"?
   let EastStations() =
      // Create a function which returns an array of stations containing "East"
      Stations
      |> Array.filter (fun name -> name.Contains "East")

   // Which stations contain "North", "South", "East" or "West"?
   let CompassStations() =
      Stations
      |> Array.filter (fun name -> name.Contains "North" || name.Contains "South" || name.Contains "East" || name.Contains "West")
      
   // Which stations contain "North", "South", "East" or "West"?
   let CompassStationsNice() =
      let compassPoints = [|"North"; "South"; "East"; "West";|]

      Stations
      |> Array.filter (fun name -> compassPoints 
                                   |> Array.exists (fun point -> name.Contains point))
      
