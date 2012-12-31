# NetRail
## Summary

An opensource .net wrapper for the api.irail.be API written in C#
using LINQ.

## Sample
			NMBS nmbs = new NMBS(NMBSLanguage.NL);
            Station hove = (from station in nmbs.Stations()
                           where station.Name.ToUpper() == "HOVE"
                            select station).First() ;
            Console.WriteLine(hove.Id);
            foreach (Departure dep in hove.Departures) {
                Console.WriteLine(String.Format("Spoor {0} -- vertraging: {1} -- richting {2}", dep.Platform, dep.Delay, dep.Direction.Name));
                Console.WriteLine(" Haltes treinstel");
                foreach (Stop s in dep.Vehicle.Stops)
                {
                    Console.WriteLine(String.Format("   {0}: {1}", s.Station.Name, s.Time.TimeOfDay));
                }
            }

## License
Licensed under the GNU GPL.