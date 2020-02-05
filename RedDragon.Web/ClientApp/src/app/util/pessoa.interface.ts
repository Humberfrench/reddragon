
interface Name
{
  title: string;
  first: string;
  last: string;
}

interface Coordinates
{
  latitude: string;
  longitude: string;
}

interface Timezone
{
  offset: string;
  description: string;
}

interface Location
{
  street: string;
  city: string;
  state: string;
  postcode: number;
  coordinates: Coordinates;
  timezone: Timezone;
}

interface Dob
{
  date: Date;
  age: number;
}

interface Registered
{
  date: Date;
  age: number;
}

interface Picture
{
  large: string;
  medium: string;
  thumbnail: string;
}

interface Pessoa
{
  gender: string;
  name: Name;
  location: Location;
  email: string;
  dob: Dob;
  registered: Registered;
  phone: string;
  cell: string;
  picture: Picture;
}

export { Name, Coordinates, Timezone, Location, Dob, Registered, Picture, Pessoa }
