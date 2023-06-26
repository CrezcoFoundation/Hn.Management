export interface DonationInterface {
        donationAreas: DonatationAreasInterface
}
export interface DonatationAreasInterface {
        collegeScholariships: number | null | undefined;
        specialEducation: number | null | undefined;
        communitySupport: number | null | undefined;
        studentMissionTrip: number | null | undefined;
        medicalAssistence: number | null | undefined;
        generalDonation: number | null | undefined;
        type?: string;
}
