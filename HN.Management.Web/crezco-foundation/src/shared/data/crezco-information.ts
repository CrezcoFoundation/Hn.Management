export interface CrezcoInformationInteface {
  cInfoId: number;
  cInfoTags: {
    tParent: string;
    tChildren: string;
  };
  cInfoTitle: string;
  cInfoDescription: string;
  cInfoUrl: string;
  cInfoIcon: string;
}

export function getCrezcoInformationObjet(): CrezcoInformationInteface[] {
  return [
    {
      cInfoId: 1,
      cInfoTags: {
        tParent: 'item-1',
        tChildren: 'item-cont1',
      },
      cInfoTitle: 'College Scholarships',
      cInfoDescription:
        'Cycles of poverty are broken through higher educational opportunities. Students in our...',
      cInfoUrl: '#',
      cInfoIcon: 'fa-solid fa-arrow-right',
    },
    {
      cInfoId: 2,
      cInfoTags: {
        tParent: 'item-2',
        tChildren: 'item-cont2',
      },
      cInfoTitle: 'Special Education',
      cInfoDescription:
        'Helpful resources are provided for children in need of special educational services that are...',
      cInfoUrl: '#',
      cInfoIcon: 'fa-solid fa-arrow-right',
    },
    {
      cInfoId: 3,
      cInfoTags: {
        tParent: 'item-3',
        tChildren: 'item-cont3',
      },
      cInfoTitle: 'Community Support',
      cInfoDescription:
        'Attending the needs in our community allows us to be a light in the world around us...',
      cInfoUrl: '#',
      cInfoIcon: 'fa-solid fa-arrow-right',
    },
    {
      cInfoId: 4,
      cInfoTags: {
        tParent: 'item-4',
        tChildren: 'item-cont4',
      },
      cInfoTitle: 'Student Trips',
      cInfoDescription:
        'Instilling an attitude and practice of service is an important value. We seek opportunities and...',
      cInfoUrl: '#',
      cInfoIcon: 'fa-solid fa-arrow-right',
    },
    {
      cInfoId: 5,
      cInfoTags: {
        tParent: 'item-5',
        tChildren: 'item-cont5',
      },
      cInfoTitle: 'Medical Assistance',
      cInfoDescription:
        'Medical emergencies can create great economic burden or result in a lack of care. Responding to...',
      cInfoUrl: '#',
      cInfoIcon: 'fa-solid fa-arrow-right',
    },
  ];
}
