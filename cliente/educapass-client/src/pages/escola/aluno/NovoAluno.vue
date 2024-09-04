<template>
    <LayoutEscola>
        <v-container>
            <h4 class="text-h4">Novo aluno</h4>
            <form class="mt-3" @submit.prevent="novoAluno">
                <v-row>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="Nome *"
                            v-model="nome"
                            required
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field
                            v-model="cpf"
                            label="CPF"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="E-mail *"
                            v-model="email"
                            type="email"
                            required
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>    
                </v-row>
                <v-row>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="Telefone *"
                            v-model="telefone"
                        ></v-text-field>
                    </v-col>    
                    <v-col cols="12" md="4">
                        <v-text-field 
                            label="Data nascimento"
                            v-model="dataNascimento"
                            type="date"
                            required
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="Numero chamada"
                            v-model="numeroChamada"
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-row>
                    <v-col cols="12" md="4">
                        <v-text-field
                            label="Nome do responsavel"
                            v-model="responsavel"
                            ></v-text-field>
                        </v-col>
                        <v-col cols="12" md="4">
                            <v-text-field
                            label="Contato do responsavel"
                            v-model="contatoResponsavel"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="4">
                        <v-text-field disabled
                            label="Numero de inscricao (Gerado altomatico)"
                            v-model="inscricao"
                        ></v-text-field>
                    </v-col>   
                </v-row>
                <v-row>
                    <v-col cols="12" md="3">
                        <v-select 
                            :item-props="salaProps" 
                            :items="items" 
                            label="Sala de aula" 
                            v-model="clase_id"
                            item-value="id">
                        </v-select>
                    </v-col>
                    <v-col cols="12" md="3">
                        <v-text-field
                            label="Total de faltas"
                            v-model="totalFalta"
                            type="number"
                        ></v-text-field>
                    </v-col>
                    <v-col cols="12" md="6">
                        <v-text-field
                            label="Senha* (Senha para o painel do aluno)"
                            v-model="senha"
                            type="password"
                            required
                            :rules="[v => !!v || 'Este campo é obrigatório']"
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-btn class="me-4" color="light-blue-darken-3" type="submit">
                    Salvar
                </v-btn>
                <v-btn :to="{ name: 'AlunosEscola' }">
                    Voltar
                </v-btn>
            </form>
        </v-container>            
    </LayoutEscola>    
</template>

<script>
    import LayoutEscola from '@/layouts/layoutEscola.vue';
    import axios from 'axios';
    import jwt_decode from 'jwt-decode';
    import Cookies from 'js-cookie';

    export default{
        components: {
            LayoutEscola
        },
        data: () => ({
            items: '',
            nome: '',
            cpf: '',
            email: '',
            telefone: '',
            dataNascimento: '',
            numeroChamada: 0,
            responsavel: '',
            contatoResponsavel: '',
            inscricao: '',
            totalFalta: 0,
            senha: '',
            escola_id: null,
            clase_id: null,
            token: '',
            decodedToken: ''
        }),
        created(){
            this.fetchSala();
        },
        methods: {
            novoAluno(){
                this.token = Cookies.get('escola_token');
                this.decodedToken = jwt_decode(this.token);
                const inscricaofor = new Date().toISOString().replace(/[-:T.]/g, '').slice(0, 14) + Math.floor(Math.random() * 100).toString().padStart(2, '0');
                const converterData = new Date(this.dataNascimento).toISOString();
                const novoAlunos = {
                    nome: this.nome,
                    cpf: this.cpf,
                    email: this.email,
                    telefone: this.telefone,
                    dataNascimento: converterData,
                    numeroChamada: this.numeroChamada,
                    responsavel: this.responsavel,
                    contatoResponsavel: this.contatoResponsavel,
                    inscricao: inscricaofor,
                    totalFalta: this.totalFalta,
                    senha: this.senha,
                    escola_id: parseInt(this.decodedToken.sub, 10),
                    clase_id: this.clase_id
                };
                console.log(novoAlunos)
                axios.post('alunos', novoAlunos, {
                    headers: {
                    'Content-Type': 'application/json'
                    }
                })
                .then(response => {
                    console.log('Aluno salva com sucesso:', response.data);
                    this.$router.push('/escola/alunos');
                })
                .catch(error => {
                    console.error('Erro ao salvar a aluno:', error.message);
                    this.$router.push('/escola/novoAluno');
                });
            },
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