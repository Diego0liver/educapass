<template>
  <LayoutEscola>
    <v-data-table :headers="headers" :items="items">
      <template v-slot:top>
        <v-toolbar flat>
          <v-toolbar-title>
              Materias <v-icon aria-hidden="false">mdi-book-open-page-variant</v-icon>
          </v-toolbar-title>
          <v-divider
            class="mx-4"
            inset
            vertical
          ></v-divider>
          <v-spacer></v-spacer>
              <v-btn
                class="mb-2"
                color="primary"
                dark
                :to="{name: 'NovaMateria'}">
                + Nova Materia
              </v-btn>
          <v-dialog v-model="dialogDelete" max-width="500px">
            <v-card>
              <v-card-title class="text-h5">Deseja excluir essa materia?</v-card-title>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue-darken-1" variant="text" @click="closeDelete">Cancelar</v-btn>
                <v-btn color="blue-darken-1" variant="text" @click="deleteItemConfirm">Excluir</v-btn>
                <v-spacer></v-spacer>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-toolbar>
      </template>
      <template v-slot:item.actions="{ item }">
        <v-icon
          class="me-2"
          size="small"
          @click="editItem(item)"
        >
          mdi-eye
        </v-icon>
        <v-icon
          size="small"
          @click="deleteItem(item)"
        >
          mdi-delete
        </v-icon>
      </template>
      <template v-slot:no-data>
        <v-btn
          color="primary"
          @click="initialize"
        >
          Reset
        </v-btn>
      </template>
    </v-data-table>
  </LayoutEscola>
</template>

<script>
  import LayoutEscola from '@/layouts/layoutEscola.vue';
  import axios from 'axios';
    export default{
      components: {
          LayoutEscola
      },
      data: () => ({
      dialogDelete: false,
      headers: [
        { title: 'Materia', key: 'nome' },
        { title: 'Descricao', key: 'descricao' },
        { title: 'Opcoes', key: 'actions', sortable: false },
      ],
      items: [],
      editedIndex: -1,
      editedItem: {
        nome: '',
        descricao: '',
      },
      defaultItem: {
        nome: '',
        descricao: '',
        
      },
    }),

    watch: {
      dialogDelete (val) {
        val || this.closeDelete()
      },
    },

    created () {
      this.initialize()
    },

    methods: {
      initialize () {
        axios.get('materia')
        .then(response => {
          this.items = response.data;
          console.log(response.data)
        })
        .catch(error => {
          console.error("Erro ao buscar os dados:", error);
        });
      },

      deleteItem (item) {
        this.editedIndex = this.items.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialogDelete = true
      },

      deleteItemConfirm () {
        this.items.splice(this.editedIndex, 1)
        this.closeDelete()
      },

      closeDelete () {
        this.dialogDelete = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },
    },
  
  }
</script>