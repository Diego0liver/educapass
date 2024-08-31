<template>
  <LayoutEscola>
    <v-data-table :headers="headers" :items="dados">
      <template v-slot:top>
        <v-toolbar flat>
          <v-toolbar-title>
            Salas de aula <v-icon aria-hidden="false">mdi-door-closed</v-icon>
          </v-toolbar-title>
          <v-divider class="mx-4" inset vertical></v-divider>
          <v-spacer></v-spacer>
          <v-btn
            class="mb-2"
            color="primary"
            dark
            :to="{ path: 'sala/NovaSala' }">
            + Nova sala
          </v-btn>
          <v-dialog v-model="dialogDelete" max-width="500px">
            <v-card>
              <v-card-title class="text-h5">Deseja deletar essa sala {{nomeItem}}?</v-card-title>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue-darken-1" variant="text" @click="closeDelete">Cancelar</v-btn>
                <v-btn color="blue-darken-1" variant="text" @click="deleteItemConfirm">Deletar</v-btn>
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
          @click="editItem(item)">
          mdi-eye
        </v-icon>
        <v-icon
          size="small"
          @click="deleteItem(item)">
          mdi-delete
        </v-icon>
      </template>
      <template v-slot:no-data>
        <v-btn
          color="primary"
          @click="initialize">
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
        { title: 'Sala', key: 'nome' },
        { title: 'Descricao', key: 'descricao' },
        { title: 'Opcoes', key: 'actions', sortable: false },
      ],
      dados: [],
      editedIndex: -1,
      editedItem: {
        nome: '',
        descricao: '',
        id: ''
      },
      defaultItem: {
        nome: '',
        descricao: '',
        id: ''
      },
      nomeItem: ''
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
        axios.get('clases')
        .then(response => {
          this.dados = response.data;
          console.log(response.data)
        })
        .catch(error => {
          console.error("Erro ao buscar os dados:", error);
        });
        
      },

    deleteItem (item) {
      this.editedIndex = this.dados.indexOf(item)
      this.nomeItem = item.nome
      this.editedItem = Object.assign({}, item)
      this.dialogDelete = true
    },

    deleteItemConfirm () {
      axios.delete(`clases/${this.editedItem.id}`)
          .then(() => {
            const index = this.dados.findIndex(d => d.id === this.editedItem.id)
            if (index !== -1) {
              this.dados.splice(index, 1)
            }
            console.log("Sala deletada com sucesso");
            this.closeDelete()
          })
          .catch(error => {
            console.error("Erro ao deletar o item:", error);
          });
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