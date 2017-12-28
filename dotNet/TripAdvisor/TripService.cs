using System.Collections.Generic;

public class TripService {

	private readonly IUserSession userSession;
	private readonly ITripDAO tripDAO;

	public TripService(IUserSession userSession, ITripDAO tripDAO) {
		this.userSession = userSession;
		this.tripDAO = tripDAO;
	}
	
	public List<Trip> getTripsByUser(User user)  {
		List<Trip> tripList = new List<Trip>();
		User loggedUser = userSession.getLoggedUser();
		bool isFriend = false;
		if (loggedUser != null) {
			foreach (User friend in user.Friends) {
				if (friend == loggedUser) {
					isFriend = true;
					break;
				}
			}
			if (isFriend) {
				tripList = tripDAO.findTripsByUser(user);
			}
			return tripList;
		} else {
			throw new UserNotLoggedInException();
		}
	}

}