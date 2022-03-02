# CarSharingPortal
A small ASP.NET Core MVC project simulating a portal with ride-sharing offers

Registered users can add new offers and manage their own offers. Any user can browse and search all currently available offers.
The offers can be published both as a passenger and as a driver. As of now, the application doesn't populate itself with any example data, so if you want to test it, you have to insert a number of new offers manually. 

Once you search for a matching offer, the backend tries to find an optimal ride for you, including all potential subroutes. This means that a driver with route Wroclaw -> Katowice -> Krakow will be matched with passengers travelling from Wroclaw to Krakow, but also from Wroclaw to Katowice and from Katowice to Krakow. On the other hand, a passenger wishing to travel from Wroclaw to Krakow will not be matched with a driver from Katowice to Krakow (since this route is not enough), but will be matched with a driver travelling from Wroclaw to Rzeszow through Krakow.
All of this assumes that the problem is simplified and that we only travel between 25 Polish cities, which can be represented as a graph. So the backend algorithm is essentialy a graph algorithm that detects acceptable routes and subroutes.

Note: this is a relatively old project, from the time I was still learning ASP.NET MVC basics. Most methods lack any proper documentation. Still, the current version works as intended and I think it is interesting enough to keep around. 
