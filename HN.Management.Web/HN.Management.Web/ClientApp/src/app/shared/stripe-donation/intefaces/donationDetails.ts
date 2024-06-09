export interface donationDetails {
  currency: string;
  // type: 'one_time' | 'recurring';
  recurring: Recurring;
  productData: ProductData;
  unit_amount: number;
  UnitAmountDecimal: number;
}

interface ProductData {
  name: string;
}

interface Recurring {
  interval: string;
}
