using tripshare.helpers;

namespace tripshare.services;

public class DestinationService : IDestinationService
{
    public Task<List<Destination>> LoadDestinationsAsync()
    {
        var destinations = new List<Destination>()
        {
            new()
            {
                Name = "Pannier",
                Address = "0233 Nobel Avenue",
                IsFavorite = false,
                Cost = 468.35,
                Rating = 3.0,
                ImageUrl = "beach_resort.png",
                Description =
                    "Vivamus metus arcu, adipiscing molestie, hendrerit at, vulputate vitae, nisl. Aenean lectus. Pellentesque eget nunc. Donec quis orci eget orci vehicula condimentum. Curabitur in libero ut massa volutpat convallis.",
                Facilities = new List<Facility>
                {
                    new(){ FacilityType = FacilityType.Dining, Image = MaterialDesignIcons.Dining},
                    new(){ FacilityType = FacilityType.Lodging, Image = MaterialDesignIcons.Hotel},
                    new(){ FacilityType = FacilityType.Swimming, Image = MaterialDesignIcons.Pool},
                    new(){ FacilityType = FacilityType.Wifi, Image = MaterialDesignIcons.Wifi},
                    new(){ FacilityType = FacilityType.Bar, Image = MaterialDesignIcons.Local_bar},
                    new(){ FacilityType = FacilityType.Cinema, Image = MaterialDesignIcons.Live_tv}
                },
            },
            new()
            {
                Name = "Zoolab",
                Address = "64 Pennsylvania Plaza",
                IsFavorite = true,
                Cost = 97.04,
                Rating = 1.6,
                ImageUrl = "theme_park.png",
                Description =
                    "Sed ante. Vivamus tortor. Duis mattis egestas metus. Ut tellus. Nulla ut erat id mauris vulputate elementum. Nullam varius.",
                Facilities = new List<Facility>
                {
                    new(){ FacilityType = FacilityType.Dining, Image = MaterialDesignIcons.Dining},
                    new(){ FacilityType = FacilityType.Wifi, Image = MaterialDesignIcons.Wifi},
                    new(){ FacilityType = FacilityType.Bar, Image = MaterialDesignIcons.Local_bar},
                    new(){ FacilityType = FacilityType.Cinema, Image = MaterialDesignIcons.Live_tv}
                },
            },
            new()
            {
                Name = "Alpha",
                Address = "72663 New Castle Drive",
                IsFavorite = true,
                Cost = 475.99,
                Rating = 3.7,
                ImageUrl = "hike.png",
                Description =
                    "Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis. Integer aliquet, massa id lobortis convallis, tortor risus dapibus augue, vel accumsan tellus nisi eu orci. Mauris lacinia sapien quis libero.",
                Facilities = new List<Facility>
                {
                    new(){ FacilityType = FacilityType.Swimming, Image = MaterialDesignIcons.Pool},
                    new(){ FacilityType = FacilityType.Hiking, Image = MaterialDesignIcons.Hiking}
                },
            },
            new()
            {
                Name = "Y-find",
                Address = "7 Cottonwood Alley",
                IsFavorite = false,
                Cost = 369.6,
                Rating = 1.7,
                ImageUrl = "hike2.png",
                Description =
                    "Cras in purus eu magna vulputate luctus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vivamus vestibulum sagittis sapien. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                Facilities = new List<Facility>
                {
                    new(){ FacilityType = FacilityType.Swimming, Image = MaterialDesignIcons.Pool},
                    new(){ FacilityType = FacilityType.Hiking, Image = MaterialDesignIcons.Hiking}
                },
            },
            new()
            {
                Name = "Latlux",
                Address = "65 Aberg Park",
                IsFavorite = true,
                Cost = 190.83,
                Rating = 2.5,
                ImageUrl = "mountain_resort.png",
                Description =
                    "Cras pellentesque volutpat dui. Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam. Suspendisse potenti. Nullam porttitor lacus at turpis.",
                Facilities = new List<Facility>
                {
                    new(){ FacilityType = FacilityType.Dining, Image = MaterialDesignIcons.Dining},
                    new(){ FacilityType = FacilityType.Lodging, Image = MaterialDesignIcons.Hotel},
                    new(){ FacilityType = FacilityType.Swimming, Image = MaterialDesignIcons.Pool},
                    new(){ FacilityType = FacilityType.Wifi, Image = MaterialDesignIcons.Wifi},
                    new(){ FacilityType = FacilityType.Hiking, Image = MaterialDesignIcons.Hiking},
                    new(){ FacilityType = FacilityType.Bar, Image = MaterialDesignIcons.Local_bar},
                    new(){ FacilityType = FacilityType.Cinema, Image = MaterialDesignIcons.Live_tv}
                },
            }
        };

        return Task.FromResult(destinations);
    }
}