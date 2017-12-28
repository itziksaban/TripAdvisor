package org.craftedsw.trip;

import java.util.List;


public interface ITripDAO {

	List<Trip> findTripsByUser(User user);

}
