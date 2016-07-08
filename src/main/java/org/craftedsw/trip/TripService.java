package org.craftedsw.trip;

import java.util.ArrayList;
import java.util.List;


public class TripService {

	private final IUserSession userSession;
	private ITripDAO tripDAO = new TripDAO();

	public TripService(IUserSession userSession, ITripDAO tripDAO) {
		this.userSession = userSession;
		this.tripDAO = tripDAO;
	}
	
	public List<Trip> getTripsByUser(User user) throws UserNotLoggedInException {
		List<Trip> tripList = new ArrayList<Trip>();
		User loggedUser = userSession.getLoggedUser();
		boolean isFriend = false;
		if (loggedUser != null) {
			for (User friend : user.getFriends()) {
				if (friend.equals(loggedUser)) {
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
