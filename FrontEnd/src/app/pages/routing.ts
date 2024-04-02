import { Routes } from '@angular/router';

const Routing: Routes = [
  {
    path :'users',
    loadChildren:()=>import('../modules/home/auth/auth.module').then((m)=>m.AuthModule)
  },
  {
    path: 'csv',
    loadChildren:()=>import('../modules/csv-parser/csv-parser.module').then((m) =>m.CsvParserModule)
  },
  {
    path :'website-maintenace',
    loadChildren:()=>import('../modules/home/website/website.module').then((m)=>m.WebsiteModule)
  },
  {
    path :'employee',
    loadChildren:()=>import('../modules/home/employeeinformation/employeeinformation.module').then((m)=>m.EmployeeinformationModule)
  },
  {
    path: 'test',
    loadChildren:()=>import('../modules/test/test.module').then((m)=>m.TestModule)
  },
  {
    path :'references',
    loadChildren:()=>import('../modules/home/setup/setup.module').then((m)=>m.SetupModule)
  },
  {
    path :'service-setup',
    loadChildren:()=>import('../modules/home/service-setup/service-setup.module').then((m)=>m.ServiceSetupModule)
  },
  {
    path :'communication',
    loadChildren:()=>import('../modules/home/communication/communication.module').then((m)=>m.CommunicationModule)
  },

  {
    path: 'termination',
    loadChildren:()=>import('../modules/home/termination/termination.module').then(m=>m.TerminationModule)
  },
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
  },
  {
    path: 'builder',
    loadChildren: () =>
      import('./builder/builder.module').then((m) => m.BuilderModule),
  },
  {
    path: 'crafted/pages/profile',
    loadChildren: () =>
      import('../modules/profile/profile.module').then((m) => m.ProfileModule),
  },
  {
    path: 'crafted/account',
    loadChildren: () =>
      import('../modules/account/account.module').then((m) => m.AccountModule),
  },
  {
    path: 'crafted/pages/wizards',
    loadChildren: () =>
      import('../modules/wizards/wizards.module').then((m) => m.WizardsModule),
  },
  {
    path: 'crafted/widgets',
    loadChildren: () =>
      import('../modules/widgets-examples/widgets-examples.module').then(
        (m) => m.WidgetsExamplesModule
      ),
  },
  {
    path: 'apps/chat',
    loadChildren: () =>
      import('../modules/apps/chat/chat.module').then((m) => m.ChatModule),
  },
  {
    path: '',
    redirectTo: '/dashboard',
    pathMatch: 'full',
  },
  {
    path: '**',
    redirectTo: 'error/404',
  },
];

export { Routing };
