using System.Collections.Generic;

public interface ITripDAO
{
    List<Trip> findTripsByUser(User user);
    void CreateFriendshipRequest(User loggedUser, User user);
}