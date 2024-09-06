<template>
  <LayoutEscola>
    <v-data-table :headers="headers" :items="dados">
      <template v-slot:top>
        <v-alert v-if="alertDelet"
            :text='alertDelet'
            type="success"
            class="mb-2"
            variant="tonal"
            closable
          ></v-alert>
        <v-toolbar flat>
          <v-toolbar-title>
              Professores <v-icon aria-hidden="false">mdi-human-male-board</v-icon>
          </v-toolbar-title>
          <v-divider class="mx-4" inset vertical></v-divider>
          <v-spacer></v-spacer>
          <v-btn class="mb-2" color="primary" dark :to="{ name: 'NovoProfessor' }">
            + Novo Professor
          </v-btn>
          <v-dialog v-model="dialogDelete" max-width="500px">
            <v-card>
              <v-card-title class="text-h5">Deseja excluir professor?</v-card-title>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue-darken-1" variant="text" @click="closeDelete">Cancelar</v-btn>
                <v-btn color="red-lighten-1" variant="text" @click="deleteItemConfirm">Excluir</v-btn>
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
          @click="detalheProfessor(item.id)"
        >
          mdi-eye
        </v-icon>
        <v-icon
          class="me-2"
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
  import Cookies from 'js-cookie';

    export default{
      components: {
        LayoutEscola
      },
      data: () => ({
      dialog: false,
      dialogDelete: false,
      headers: [
        { title: 'Nome', key: 'nome' },
        { title: 'Inscricao', key: 'inscricao' },
        { title: 'CPF', key: 'cpf' },
        { title: 'E-mail', key: 'email' },
        { title: 'Opcoes', key: 'actions', sortable: false },
      ],
      dados: [],
      editedIndex: -1,
      editedItem: {
        nome: '',
        inscricao: 0,
        cpf: '',
        email: '',
        alertDelet: ''
      },
      defaultItem: {
        nome: '',
        inscricao: 0,
        cpf: '',
        email: '',
        alertDelet: ''
      },
    }),

    watch: {
      dialog (val) {
        val || this.close()
      },
      dialogDelete (val) {
        val || this.closeDelete()
      },
    },

    created () {
      this.initialize()
    },
    methods: {
      initialize () {
        this.token = Cookies.get('escola_token')
        axios.get('professor', {
          headers: {
            'Authorization': `Bearer ${this.token}`,
          }
        })
        .then(response => {
          this.dados = response.data;
          console.log(response.data)
        })
        .catch(error => {
          console.error("Erro ao buscar os dados:", error);
          console.log(this.token)
        });
      },
      detalheProfessor(id) {
        this.$router.push({ name: 'DetalhesProfessor', params: { id } });
      },

      deleteItem (item) {
        this.editedIndex = this.dados.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialogDelete = true
      },

      deleteItemConfirm () {
        axios.delete(`professor/${this.editedItem.id}`)
        .then(() => {
          const index = this.dados.findIndex(d => d.id === this.editedItem.id)
          if (index !== -1) {
            this.dados.splice(index, 1)
          }
          console.log("Professor deletada com sucesso");
          this.alertDelet = "Professor deletada com sucesso";
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