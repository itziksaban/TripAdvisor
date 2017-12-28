using System.Collections.Generic;

public interface ITripDAO
{
    List<Trip> findTripsByUser(User user);
}