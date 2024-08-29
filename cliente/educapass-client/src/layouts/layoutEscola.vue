<template>
    <v-app-bar
        color="light-blue-darken-4"
        prominent
    >
        <v-app-bar-nav-icon variant="text" @click.stop="drawer = !drawer"></v-app-bar-nav-icon>

        <v-toolbar-title class="font-new">Educapass - Escola</v-toolbar-title>

        <v-spacer></v-spacer>

        <template v-if="$vuetify.display.mdAndUp">
        <v-btn icon="mdi-account" variant="text"></v-btn>
        </template>
    </v-app-bar>

    <v-navigation-drawer
        v-model="drawer"
        :location="$vuetify.display.mobile ? 'bottom' : undefined"
        temporary
    >
    <v-list density="compact" nav class="font-new">
      <img style="width: 32px;" src="@/assets/logoEducapass.png"/>
        <v-list-item prepend-icon="mdi-view-dashboard" title="Dashboard" :to="{ path: '/escola/Dashboard' }"></v-list-item>
        <v-list-item prepend-icon="mdi-account-school" title="Alunos" :to="{ path: '/escola/AlunosEscola' }"></v-list-item>
        <v-list-item prepend-icon="mdi-human-male-board" title="Professores" :to="{ path: '/escola/ProfessorEscola' }"></v-list-item>
        <v-list-item prepend-icon="mdi-door-closed" title="Salas" :to="{ path: '/escola/SalasEscola' }"></v-list-item>
        <v-list-item prepend-icon="mdi-book-open-page-variant" title="Materias" :to="{ path: '/escola/MateriasEscola' }"></v-list-item>
        <v-list-item prepend-icon="mdi-video-vintage" title="Aulas online" :to="{ path: '/escola/AulasEscola' }"></v-list-item>
    </v-list>
        
    </v-navigation-drawer>

    <v-main style="height: 500px;">
        <v-card-text>
            <slot></slot>
        </v-card-text>
    </v-main>
  </template>

<script>
export default {
  data: () => ({
    drawer: false,
    group: null,
  }),

  watch: {
    group () {
      this.drawer = false
    },
  },
}
</script>
