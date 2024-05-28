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
      degree: 'PSC',
      date: '2023',
    },
    {
      id: 10,
      url: 'grad-12.webp',
      degree: 'ED',
      date: '2023',
    },
    {
      id: 11,
      url: 'grad-11.webp',
      degree: 'ED',
      date: '2023',
    },
    {
      id: 12,
      url: 'grad-10.webp',
      degree: 'NS',
      date: '2023',
    },
  ];
}

export interface StoryAdminInterface {
  id: number;
  adminInfo: {
    name: string;
    role: string;
  };
  url: string;
}

export function getInfoAdminObject(): StoryAdminInterface[] {
  return [
    {
      id: 1,
      adminInfo: {
        name: 'Amanda Corea',
        role: 'FE',
      },
      url: 'founder-1_story.webp',
    },
    {
      id: 2,
      adminInfo: {
        name: 'Ashley McMullen',
        role: 'BC',
      },
      url: 'founder-2_story.webp',
    },
    {
      id: 3,
      adminInfo: {
        name: 'Marci Corea',
        role: 'BS',
      },
      url: 'founder-3_story.webp',
    },
    /* {
      id: 4,
      admin: {
        name: 'Erica Russell',
        role: 'BT',
      },
      url: 'founder-4_story.webp',
    }, */
  ];
}
