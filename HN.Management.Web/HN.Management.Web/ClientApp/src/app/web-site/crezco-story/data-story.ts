export interface StoryInformation {
  id: number;
  url: string;
  degree: string;
  date: string;
}

export function getStoryInfoObject(): StoryInformation[] {
  return [
    {
      id: 1,
      url: 'grad-13.png',
      degree: 'TI',
      date: '2013',
    },
    {
      id: 2,
      url: 'grad-9_story.webp',
      degree: 'TI',
      date: '2013',
    },
    {
      id: 3,
      url: 'grad-8_story.webp',
      degree: 'PS',
      date: '2017',
    },
    {
      id: 4,
      url: 'grad-7_story.webp',
      degree: 'TI',
      date: '2018',
    },
    {
      id: 5,
      url: 'grad-6_story.webp',
      degree: 'TI',
      date: '2018',
    },
    {
      id: 6,
      url: 'grad-5_story.webp',
      degree: 'TI',
      date: '2018',
    },
    {
      id: 7,
      url: 'grad-4_story.webp',
      degree: 'GD',
      date: '2019',
    },
    {
      id: 8,
      url: 'grad-2_story.webp',
      degree: 'PS',
      date: '2019',
    },
    {
      id: 9,
      url: 'grad-1_story.webp',
      degree: 'BS Clinical Psychology',
      date: '2023',
    },
    {
      id: 10,
      url: 'grad-12.webp',
      degree: 'BS Education',
      date: '2023',
    },
    {
      id: 11,
      url: 'grad-11.webp',
      degree: 'BS Education',
      date: '2023',
    },
    {
      id: 12,
      url: 'grad-10.webp',
      degree: 'BS Nursing',
      date: '2023',
    },
  ];
}

export interface StoryAdminInterface {
  sAdminId: number;
  sInfoAdmin: {
    sAdminName: string;
    sAdminDesc: string;
  };
  sInfoAdminUrl: string;
}

export function getInfoAdminObject(): StoryAdminInterface[] {
  return [
    {
      sAdminId: 1,
      sInfoAdmin: {
        sAdminName: 'Amanda Corea',
        sAdminDesc: 'Founder & Executive Director',
      },
      sInfoAdminUrl: 'founder-1_story.webp',
    },
    {
      sAdminId: 2,
      sInfoAdmin: {
        sAdminName: 'Ashley McMullen',
        sAdminDesc: 'Board Chair',
      },
      sInfoAdminUrl: 'founder-2_story.webp',
    },
    {
      sAdminId: 3,
      sInfoAdmin: {
        sAdminName: 'Marci Corea',
        sAdminDesc: 'Board Secretary',
      },
      sInfoAdminUrl: 'founder-3_story.webp',
    },
    /* {
      sAdminId: 4,
      sInfoAdmin: {
        sAdminName: 'Erica Russell',
        sAdminDesc: 'Board Treasurer',
      },
      sInfoAdminUrl: 'founder-4_story.webp',
    }, */
  ];
}
