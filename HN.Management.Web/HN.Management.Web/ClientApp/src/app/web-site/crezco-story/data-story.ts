export interface StoryInformationInterface {
  sInfoId: number;
  sInfoTags: {
    tagParent: string;
    tagChildren: string;
    tagBrother: string;
  };
  sInfoUrl: string;
  sInfoDegree: string;
  sInfoDate: string;
}

export function getStoryInfoObject(): StoryInformationInterface[] {
  return [
    {
      sInfoId: 1,
      sInfoTags: {
        tagParent: 'card-grad',
        tagChildren: 'card-grad_img',
        tagBrother: 'card-grad_content',
      },
      sInfoUrl: 'grad-1_story.webp',
      sInfoDegree: 'BS Clinical Psychology',
      sInfoDate: '2023',
    },
    {
      sInfoId: 2,
      sInfoTags: {
        tagParent: 'card-grad',
        tagChildren: 'card-grad_img',
        tagBrother: 'card-grad_content',
      },
      sInfoUrl: 'grad-2_story.webp',
      sInfoDegree: 'BS Educational Psychology',
      sInfoDate: '2019',
    },
    /* {    
        sInfoId: 3,
        sInfoTags: {
            tagParent: 'card-grad',
            tagChildren: 'card-grad_img',
            tagBrother: 'card-grad_content',
        },
        sInfoUrl: 'grad-3_story.webp',
        sInfoDegree: 'BA Graphic Design',
        sInfoDate: '2020',
    }, */
    {
      sInfoId: 4,
      sInfoTags: {
        tagParent: 'card-grad',
        tagChildren: 'card-grad_img',
        tagBrother: 'card-grad_content',
      },
      sInfoUrl: 'grad-4_story.webp',
      sInfoDegree: 'BA Graphic Design',
      sInfoDate: '2019',
    },
    {
      sInfoId: 5,
      sInfoTags: {
        tagParent: 'card-grad',
        tagChildren: 'card-grad_img',
        tagBrother: 'card-grad_content',
      },
      sInfoUrl: 'grad-5_story.webp',
      sInfoDegree: 'BS Computer Engineering',
      sInfoDate: '2018',
    },
    {
      sInfoId: 6,
      sInfoTags: {
        tagParent: 'card-grad',
        tagChildren: 'card-grad_img',
        tagBrother: 'card-grad_content',
      },
      sInfoUrl: 'grad-6_story.webp',
      sInfoDegree: 'BS Computer Engineering',
      sInfoDate: '2018',
    },
    {
      sInfoId: 7,
      sInfoTags: {
        tagParent: 'card-grad',
        tagChildren: 'card-grad_img',
        tagBrother: 'card-grad_content',
      },
      sInfoUrl: 'grad-7_story.webp',
      sInfoDegree: 'BS Computer Engineering',
      sInfoDate: '2018',
    },
    {
      sInfoId: 8,
      sInfoTags: {
        tagParent: 'card-grad',
        tagChildren: 'card-grad_img',
        tagBrother: 'card-grad_content',
      },
      sInfoUrl: 'grad-8_story.webp',
      sInfoDegree: 'BS Educational Psychology',
      sInfoDate: '2017',
    },
    {
      sInfoId: 9,
      sInfoTags: {
        tagParent: 'card-grad',
        tagChildren: 'card-grad_img',
        tagBrother: 'card-grad_content',
      },
      sInfoUrl: 'grad-9_story.webp',
      sInfoDegree: 'BS Computer Engineering',
      sInfoDate: '2013',
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
    {
      sAdminId: 4,
      sInfoAdmin: {
        sAdminName: 'Erica Russell',
        sAdminDesc: 'Board Treasurer',
      },
      sInfoAdminUrl: 'founder-4_story.webp',
    },
  ];
}
