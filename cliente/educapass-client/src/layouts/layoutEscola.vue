<template>
    <v-app-bar
        color="indigo-darken-3" prominent>
        <v-app-bar-nav-icon variant="text" @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
        <v-toolbar-title class="font-new">{{nomeEscola}} - Escola</v-toolbar-title>
        <v-spacer></v-spacer>
        <template v-if="$vuetify.display.mdAndUp">
        <v-menu
            transition="slide-y-transition"
          >
            <template v-slot:activator="{ props }">
              <v-btn icon="mdi-account" variant="text" v-bind="props"></v-btn>
            </template>
            <v-list>
              <v-list-item>
                <v-btn
                  color='success'
                  prepend-icon='mdi-keyboard-backspace'
                  text='Sair/Logout'
                  variant='tonal'
                  class="text-none"
                  size="small"
                  flat
                  @click="logout"
                ></v-btn>
              </v-list-item>
              <v-list-item>
                <v-btn
                  color='indigo-darken-3'
                  prepend-icon='mdi-account'
                  text='Perfil/Escola'
                  variant='tonal'
                  class="text-none"
                  size="small"
                  flat
                ></v-btn>
              </v-list-item>
            </v-list>
        </v-menu>
        </template>
    </v-app-bar>

    <v-navigation-drawer
        v-model="drawer"
        :location="$vuetify.display.mobile ? 'bottom' : undefined"
        temporary
    >
    <v-list density="compact" nav class="font-new" color='indigo-darken-3'>
      <img style="width: 32px;" src="@/assets/logoEducapass.png"/>
        <v-list-item prepend-icon="mdi-view-dashboard" title="Dashboard" :to="{ name: 'EscolaHome' }"></v-list-item>
        <v-list-item prepend-icon="mdi-account-school" title="Alunos" :to="{ name: 'AlunosEscola' }"></v-list-item>
        <v-list-item prepend-icon="mdi-human-male-board" title="Professores" :to="{ name: 'ProfessorEscola' }"></v-list-item>
        <v-list-item prepend-icon="mdi-door-closed" title="Salas" :to="{ name: 'SalasEscola' }"></v-list-item>
        <v-list-item prepend-icon="mdi-book-open-page-variant" title="Materias" :to="{ name: 'MateriasEscola' }"></v-list-item>
        <v-list-item prepend-icon="mdi-video-vintage" title="Aulas online" :to="{ name: 'AulasEscola' }"></v-list-item>
    </v-list>
        
    </v-navigation-drawer>

    <v-main style="height: 500px;">
        <v-card-text>
            <slot></slot>
        </v-card-text>
    </v-main>
  </template>

<script>
import Cookies from 'js-cookie';
import jwt_decode from 'jwt-decode';

export default {
  data: () => ({
    drawer: false,
    group: null,
    nomeEscola: 'EducaPass',
  }),

  methods:{
    logout(){
      Cookies.remove('escola_token');
      this.$router.push('/');
    }
  },
  mounted() {
    const token = Cookies.get('escola_token');
    const decode = jwt_decode(token);
    this.nomeEscola = decode.Escola;
  },
  watch: {
    group () {
      this.drawer = false
    },
  },
}
</script>
