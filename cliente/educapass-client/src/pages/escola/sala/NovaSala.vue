<template>
    <LayoutEscola>
        <v-container>
            <h4 class="text-h4">Nova sala</h4>
            <form class="mt-3" @submit.prevent="novaSala">
                <v-row>
                    <v-col cols="12" md="6">
                        <v-text-field
                            label="Sala"
                            required
                            v-model="nome"
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="6">
                        <v-text-field
                            v-model="descricao"
                            label="Descricao"
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-btn class="me-4" color="light-blue-darken-3" type="submit">
                    Salvar
                </v-btn>
                <v-btn :to="{ path: '/escola/SalasEscola' }">
                    Voltar
                </v-btn>
            </form>
        </v-container>            
    </LayoutEscola>    
</template>
  

<script>
    import LayoutEscola from '@/layouts/layoutEscola.vue';
    import axios from 'axios';

        export default{
            components: {
                LayoutEscola
            },
        data(){
            return {
            nome: '',
            descricao: '',
            escola_id: 1
        }
        },
        methods: {
            novaSala(){
                const novaSalas = {
                    nome : this.nome,
                    descricao : this.descricao,
                    escola_id : this.escola_id
                };
                
                axios.post('clases', novaSalas, {
                    headers: {
                    'Content-Type': 'application/json' // Certifique-se de que o servidor espera JSON
                    }
                })
                .then(response => {
                    console.log('Sala salva com sucesso:', response.data);
                    this.$router.push('/escola/SalasEscola');
                })
                .catch(error => {
                    console.error('Erro ao salvar a sala:', error.response ? error.response.data : error.message);
                    // Adicione lógica aqui para lidar com o erro, como mostrar uma mensagem de erro para o usuário
                });
            }
        }
        }
</script>      