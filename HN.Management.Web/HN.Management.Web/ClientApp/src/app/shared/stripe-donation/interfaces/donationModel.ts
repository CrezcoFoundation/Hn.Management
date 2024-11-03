export interface donationModel {
  id?: string;
  currency: string;
  metadata: Metadata;
  productData?: Metadata;
  nickname?: string;
  recurring: Recurring;
  TransformQuantity?: null;
  unitAmount: number;
}

interface Recurring {
  interval: string;
  aggregateUse?: null;
  intervalCount?: string;
  usageType?: string;
}

interface Metadata {
  name: string;
}
