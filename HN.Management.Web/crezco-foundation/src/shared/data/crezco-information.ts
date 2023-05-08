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
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Nemo nostrum enim nulla distinctio.',
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
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Nemo nostrum enim nulla distinctio.',
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
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Nemo nostrum enim nulla distinctio.',
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
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Nemo nostrum enim nulla distinctio.',
      cInfoUrl: '#',
      cInfoIcon: 'fa-solid fa-arrow-right',
    },
    {
      cInfoId: 5,
      cInfoTags: {
        tParent: 'item-5',
        tChildren: 'item-cont5',
      },
      cInfoTitle: 'Waiting Section',
      cInfoDescription:
        'Lorem ipsum dolor sit amet consectetur adipisicing elit. Nemo nostrum enim nulla distinctio.',
      cInfoUrl: '#',
      cInfoIcon: 'fa-solid fa-arrow-right',
    },
  ];
}
