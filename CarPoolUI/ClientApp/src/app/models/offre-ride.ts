export interface OfferRide {
    "offeredRides":{
        "offeredRideId":string,
        "source": string,
        "destination": string,
        "date":Date,
        "totalSeats": number,
        "availableSeats": number,
        "time": number,
        "price": number
    },
    "locations":string[]|null;
}