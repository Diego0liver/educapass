

import { createRouter, createWebHistory } from 'vue-router/auto'
import Auth from '../service/middleware.js';
import Index from '@/pages/index.vue';
import Dashboard from '@/pages/escola/Dashboard.vue';
import AlunosEscola from '@/pages/escola/AlunosEscola.vue';
import ProfessorEscola from '@/pages/escola/ProfessorEscola.vue';
import SalasEscola from '@/pages/escola/SalasEscola.vue';
import MateriasEscola from '@/pages/escola/MateriasEscola.vue';
import AulasEscola from '@/pages/escola/AulasEscola.vue';
import NovaSala from '@/pages/escola/sala/NovaSala.vue';
import NovoAluno from '@/pages/escola/aluno/NovoAluno.vue';
import DetalhesAluno from '@/pages/escola/aluno/DetalhesAluno.vue';
import NotFound from '@/pages/NotFound.vue';
import NovoProfessor from '@/pages/escola/professor/NovoProfessor.vue';
import DetalhesProfessor from '@/pages/escola/professor/DetalhesProfessor.vue';
import NovaMateria from '@/pages/escola/materia/NovaMateria.vue';

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Index,
    beforeEnter: Auth.authEscolaViewLogin
  },
  {
    path: '/escola',
    name: 'EscolaHome',
    component: Dashboard,
    beforeEnter: Auth.authEscola
  },
  {
    path: '/escola/alunos',
    name: 'AlunosEscola',
    component: AlunosEscola,
    beforeEnter: Auth.authEscola
  },
  {
    path: '/escola/professores',
    name: 'ProfessorEscola',
    component: ProfessorEscola,
    beforeEnter: Auth.authEscola
  },
  {
    path: '/escola/salas',
    name: 'SalasEscola',
    component: SalasEscola,
    beforeEnter: Auth.authEscola
  },
  {
    path: '/escola/materias',
    name: 'MateriasEscola',
    component: MateriasEscola,
    beforeEnter: Auth.authEscola
  },
  {
    path: '/escola/aulas',
    name: 'AulasEscola',
    component: AulasEscola,
    beforeEnter: Auth.authEscola
  },
  {
    path: '/escola/novaSala',
    name: 'NovaSala',
    component: NovaSala,
    beforeEnter: Auth.authEscola
  },
  {
    path: '/escola/novaMateria',
    name: 'NovaMateria',
    component: NovaMateria,
    beforeEnter: Auth.authEscola
  },
  {
    path: '/escola/novoAluno',
    name: 'NovoAluno',
    component: NovoAluno,
    beforeEnter: Auth.authEscola
  },
  {
    path: '/escola/detalhesAluno/:id',
    name: 'DetalhesAluno',
    component: DetalhesAluno,
    beforeEnter: Auth.authEscola,
    props: true
  },
  {
    path: '/escola/novoProfessor',
    name: 'NovoProfessor',
    component: NovoProfessor,
    beforeEnter: Auth.authEscola
  },
  {
    path: '/escola/detalhesProfessor/:id',
    name: 'DetalhesProfessor',
    component: DetalhesProfessor,
    beforeEnter: Auth.authEscola,
    props: true
  },
  {
    path: '/:pathMatch(.*)*',
    name: 'NotFound',
    component: NotFound,
  },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

// Workaround for https://github.com/vitejs/vite/issues/11804
router.onError((err, to) => {
  if (err?.message?.includes?.('Failed to fetch dynamically imported module')) {
    if (!localStorage.getItem('vuetify:dynamic-reload')) {
      console.log('Reloading page to fix dynamic import error')
      localStorage.setItem('vuetify:dynamic-reload', 'true')
      location.assign(to.fullPath)
    } else {
      console.error('Dynamic import error, reloading page did not fix it', err)
    }
  } else {
    console.error(err)
  }
})

router.isReady().then(() => {
  localStorage.removeItem('vuetify:dynamic-reload')
})

export default router
