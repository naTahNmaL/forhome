import {CountryModel} from "./country.model";
import {CurrencyModel} from "./currency.model";

export class defaultData{
  constructor(
    public id: number,
    public countryList: CountryModel[],
    public currencyList: CurrencyModel[]
  )
    { }
}
