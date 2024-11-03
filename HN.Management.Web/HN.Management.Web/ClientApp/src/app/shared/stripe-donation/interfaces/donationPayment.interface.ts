export interface DonationPaymentInterface {
  Amount: number | undefined;
  Currency: string;
  AutomaticPaymentMethods:{
    Enabled: boolean
  };
  Customer: string | undefined;
  clientSecret?: string;
}
