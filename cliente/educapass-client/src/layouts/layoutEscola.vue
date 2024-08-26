<template>
    <v-app-bar
        color="indigo-darken-4"
        prominent
    >
        <v-app-bar-nav-icon variant="text" @click.stop="drawer = !drawer"></v-app-bar-nav-icon>

        <v-toolbar-title>Educapass - Escola</v-toolbar-title>

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
    <v-list density="compact" nav>
        <v-list-item prepend-icon="mdi-view-dashboard" title="Dashboard" :to="{ path: 'Dashboard' }"></v-list-item>
        <v-list-item prepend-icon="mdi-account-school" title="Alunos" :to="{ path: 'AlunosEscola' }"></v-list-item>
        <v-list-item prepend-icon="mdi-human-male-board" title="Professores" value="shared"></v-list-item>
        <v-list-item prepend-icon="mdi-book-open-page-variant" title="Materias" value="starred"></v-list-item>
        <v-list-item prepend-icon="mdi-table-chair" title="Salas" value="starred"></v-list-item>
        <v-list-item prepend-icon="mdi-video-vintage" title="Aulas online" value="starred"></v-list-item>
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