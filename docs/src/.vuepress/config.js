const { description } = require('../../package')

module.exports = {
  title: 'Базы данных. Полный курс',
  description: description,
  theme: 'yuu',
  head: [
    ['meta', { name: 'theme-color', content: '#3eaf7c' }],
    ['meta', { name: 'apple-mobile-web-app-capable', content: 'yes' }],
    ['meta', { name: 'apple-mobile-web-app-status-bar-style', content: 'black' }]
  ],
  base: '/itmo-db-course/',
  themeConfig: {
    searchPlaceholder: 'Индекс это...',
    repo: 'https://github.com/sashafromlibertalia/itmo-db-course.git',
    repoLabel: 'Пофиксить баги!',
    editLinks: false,
    docsDir: '',
    editLinkText: '',
    lastUpdated: false,
    nav: [
      {
        text: 'Весь курс',
        link: '/exam/',
      },
      {
        text: 'GitHub',
        link: 'https://github.com/sashafromlibertalia/itmo-db-course'
      }
    ],
    sidebar: {
      '/exam/': [
        {
          title: 'Полный курс',
          collapsable: false,
          children: Array(40).fill().map((_, i) => `Question_${i + 1}.md`)
        }
      ],
    }
  },
  plugins: [
    '@vuepress/plugin-back-to-top',
    '@vuepress/plugin-medium-zoom',
  ]
}
