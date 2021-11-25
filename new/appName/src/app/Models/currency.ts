export class Currency {
    Name: String | undefined;
    Unit: String | undefined;
    CurrencyCode: String | undefined;
    Country: String | undefined;
    Change: String | undefined;
    Rate: String ='';

}

export class DateCurrenctRate{
    Date:Date | undefined;
    Currency:Currency =new Currency();

}

