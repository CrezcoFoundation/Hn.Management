export interface donationDetails {
  currency: string;
  type?: 'one-time' | 'recurring';
  recurring?: Recurring;
  productData: ProductData;
  unitAmount?: number;
  UnitAmountDecimal?: number;
}

interface ProductData {
  name: string;
}

interface Recurring {
  interval: string;
}
