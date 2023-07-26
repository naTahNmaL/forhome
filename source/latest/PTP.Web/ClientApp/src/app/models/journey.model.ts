export class Journey {
  id: number;
  userId: number;
  name: string;
  description: string;
  country: string;
  place: string;
  startDate: Date;
  endDate: Date;
  currency: string;
  status: string;
  amount: number;

  constructor(
    id: number,
    userId: number,
    name: string,
    description: string,
    country: string,
    place: string,
    startDate: Date,
    endDate: Date,
    currency: string,
    status: string,
    amount: number,
  ) {
    this.id = id;
    this.userId = userId;
    this.name = name;
    this.description = description;
    this.country = country;
    this.place = place;
    this.startDate = startDate;
    this.endDate = endDate;
    this.currency = currency;
    this.status = status;
    this.amount = amount;

  }
}
