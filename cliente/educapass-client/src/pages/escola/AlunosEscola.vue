<template>
  <LayoutEscola>
    <v-data-table :headers="headers" :items="dados">
      <template v-slot:top>
        <v-toolbar flat>
          <v-toolbar-title>
              Alunos <v-icon aria-hidden="false">mdi-account-school</v-icon>
          </v-toolbar-title>
          <v-divider class="mx-4" inset vertical></v-divider>
          <v-spacer></v-spacer>
          <v-btn
            class="mb-2"
            color="primary"
            dark
            :to="{ path: 'aluno/NovoAluno' }">
            + Novo Aluno
          </v-btn>
          <v-dialog v-model="dialogDelete" max-width="500px">
            <v-card>
              <v-card-title class="text-h5">Deseja excluir aluno?</v-card-title>
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
        { title: 'Data', key: 'data' },
        { title: 'Turma', key: 'turma' },
        { title: 'Numero chamada', key: 'numero' },
        { title: 'Opcoes', key: 'actions', sortable: false },
      ],
      dados: [],
      editedIndex: -1,
      editedItem: {
        nome: '',
        inscricao: 0,
        data: '',
        turma: '',
        numero: 0,
      },
      defaultItem: {
        nome: '',
        inscricao: 0,
        data: '',
        turma: '',
        numero: 0,
      },
    }),

    computed: {
      formTitle () {
        return this.editedIndex === -1 ? 'New Item' : 'Edit Item'
      },
    },

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
        this.dados = [
          {
            nome: 'Donut',
            inscricao: 452,
            data: '20/95',
            turma: '8 - A',
            numero: 4,
          },
          {
            nome: 'KitKat',
            inscricao: 518,
            data: '20/20',
            turma: '0 - B',
            numero: 7,
          },
        ]
      },

      deleteItem (item) {
        this.editedIndex = this.dados.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialogDelete = true
      },

      deleteItemConfirm () {
        this.dados.splice(this.editedIndex, 1)
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