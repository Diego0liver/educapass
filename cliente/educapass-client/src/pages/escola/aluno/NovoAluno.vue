<template>
    <LayoutEscola>
        <v-container>
            <h4 class="text-h4">Novo aluno</h4>
            <form class="mt-3">
                <v-row>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="Nome *"
                            required
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="CPF"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="E-mail *"
                            type="E-mail"
                            required
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>    
                </v-row>
                <v-row>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="Telefone *"
                        ></v-text-field>
                    </v-col>    
                    <v-col cols="12" md="4">
                        <v-text-field 
                            label="Data nascimento"
                            type="date"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="Numero chamada"
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-row>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="Nome do responsavel"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="Contato do responsavel"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field disabled
                            label="Numero de inscricao (Gerado altomatico)"
                        ></v-text-field>
                    </v-col>   
                </v-row>
                <v-row>
                    <v-col cols="12" md="3">
                        <v-select :item-props="salaProps" :items="items" label="Sala de aula"></v-select>
                    </v-col>
                    <v-col cols="12" md="3">
                        <v-text-field
                            label="Total de faltas"
                            type="number"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="6">
                        <v-text-field
                            label="Senha* (Senha para o painel do aluno)"
                            type="password"
                            required
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-btn class="me-4" color="light-blue-darken-3" type="submit">
                    Salvar
                </v-btn>
                <v-btn :to="{ path: '/escola/AlunosEscola' }">
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
        data: () => ({
            items: ''
        }),
        created(){
            this.fetchSala();
        },
        methods: {
            async fetchSala() {
                try {
                    const response = await axios.get('clases');
                    console.log(response.data); 
                    this.items = response.data;
                } catch (error) {
                    console.error('Erro ao buscar clase:', error);
                }
            },
            salaProps (items) {
                return {
                    title: items.nome,
                    subtitle: items.descricao
                }
            },
        }
    }
</script>      