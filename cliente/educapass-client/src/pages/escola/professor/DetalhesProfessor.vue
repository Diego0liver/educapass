<template>
    <LayoutEscola>
        <v-card
            class="mx-auto"
            :subtitle="nome"
            prepend-icon="mdi-human-male-board"
            width="1000">
            <template v-slot:append>
                <v-btn
                class="text-none"
                color="primary"
                text="Create goal"
                variant="Voltar"
                prepend-icon="mdi-keyboard-backspace"
                :to="{ name: 'ProfessorEscola' }">
                Voltar
                </v-btn>
            </template>
            <template v-slot:title>
                <span class="font-weight-black"></span>
            </template>
            <v-card-text class="bg-surface-light pt-4">
                <v-list lines="two" class="rounded">
                    <v-list-item
                        :subtitle="inscricao">
                        <template v-slot:title>
                            Inscricao<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                    <v-divider></v-divider>
                    <v-divider></v-divider>
                    <v-list-item
                        :subtitle="email">
                        <template v-slot:title>
                            E-mail<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                    <v-divider></v-divider>
                    <v-list-item
                        :subtitle="telefone">
                        <template v-slot:title>
                            Telefone<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                    <v-divider></v-divider>
                    <v-list-item
                        :subtitle="cpf">
                        <template v-slot:title>
                            CPF<span class="font-weight-black"></span>
                        </template>
                    </v-list-item>
                </v-list>
            </v-card-text>
        </v-card>
        <v-card
            class="mx-auto mt-4"
            subtitle="Clases"
            prepend-icon="mdi-door-closed"
            width="1000">
            <template v-slot:append>
                <div class="text-center">
                    <v-dialog
                    v-model="modalMateria"
                    max-width="400"
                    persistent
                    >
                    <template v-slot:activator="{ props: activatorProps }">
                        <v-btn 
                            v-bind="activatorProps"
                            class="text-none"
                            color="primary"
                            text="Create goal"
                            variant="Voltar">
                        + Vincular clase
                        </v-btn>
                    </template>
                    <form @submit.prevent="vincularClase">
                        <v-card
                            prepend-icon="mdi-door-closed"
                            title="Escolha uma sala de aula">
                            <v-select
                                :item-props="salaProps"
                                :items="salas"
                                v-model="clase_id"
                                item-value="id"
                                label="Salas"
                            ></v-select>
                            <template v-slot:actions>
                            <v-spacer></v-spacer>
                            <v-btn @click="modalMateria = false">
                                Voltar
                            </v-btn>
                            <v-btn type="submit">
                                Salvar
                            </v-btn>
                            </template>
                        </v-card>
                    </form>
                    </v-dialog>
                </div>
            </template>
            <v-card-text class="bg-surface-light pt-4">
                <v-list lines="two" class="rounded">
                    <v-list-item
                        v-for="(item, index) in salasVinculadas" :key="index"
                        :subtitle="item.clase.descricao">
                        <template v-slot:title>
                            {{ item.clase.nome }}<span class="font-weight-black"></span>
                        </template>
                        <v-divider></v-divider>
                    </v-list-item>
                </v-list>
            </v-card-text>
        </v-card>
        <v-card
            class="mx-auto mt-4"
            subtitle="Materia"
            prepend-icon="mdi-book-open-page-variant"
            width="1000">
            <template v-slot:append>
                <div class="text-center">
                    <v-dialog
                    v-model="dialog"
                    max-width="400"
                    persistent
                    >
                    <template v-slot:activator="{ props: activatorProps }">
                        <v-btn 
                            v-bind="activatorProps"
                            class="text-none"
                            color="primary"
                            text="Create goal"
                            variant="Voltar">
                        + Vincular materia
                        </v-btn>
                    </template>
                    <form @submit.prevent="vincularMateria">
                        <v-card
                            prepend-icon="mdi-book-open-page-variant"
                            title="Escolha uma materia">
                            <v-select
                                :item-props="materiaProps"
                                :items="materias"
                                v-model="materia_id"
                                item-value="id"
                                label="Materias"
                            ></v-select>
                            <template v-slot:actions>
                            <v-spacer></v-spacer>
                            <v-btn @click="dialog = false">
                                Voltar
                            </v-btn>
                            <v-btn type="submit">
                                Salvar
                            </v-btn>
                            </template>
                        </v-card>
                    </form>
                    </v-dialog>
                </div>
            </template>
            <v-card-text class="bg-surface-light pt-4">
                <v-list lines="two" class="rounded">
                    <v-list-item
                    v-for="(item, index) in materiasVinculadas" :key="index"
                        :subtitle="item.materia.descricao">
                        <template v-slot:title>
                            {{ item.materia.nome }}<span class="font-weight-black"></span>
                        </template>
                        <v-divider></v-divider>
                    </v-list-item>
                </v-list>
            </v-card-text>
        </v-card>
    </LayoutEscola>
</template>

<script>
import LayoutEscola from '@/layouts/layoutEscola.vue';
import { useRoute } from 'vue-router';
import axios from 'axios';

export default {
    components: {
        LayoutEscola
    },
    data() {
        return {
            id: null,
            nome: '',
            email: '',
            inscricao: '',
            telefone: '',
            cpf: '',
            dialog: false,
            modalMateria: false,
            salas: '',
            materias: '',
            clase_id: null,
            professor_id: null,
            materia_id: null,
            salasVinculadas: [],
            materiasVinculadas: []
        };
    },
    created(){
        this.fetchSala();
        this.fetchMateria();
    },
    mounted() {
        const route = useRoute();
        this.id = route.params.id;
        
        axios.get(`professor/${this.id}`).then((res)=>{
            this.nome = res.data.res.nome
            this.email = res.data.res.email
            this.inscricao = res.data.res.inscricao
            this.telefone = res.data.res.telefone
            this.cpf = res.data.res.cpf
        })
        axios.get(`classeProfessor/${this.id}/classes`).then((res)=>{
            //console.log(res.data)
            this.salasVinculadas = res.data
        })
        axios.get(`ProfessorMateria/${this.id}/materia`).then((res)=>{
            console.log(res.data)
            this.materiasVinculadas = res.data
        })
    },
    methods:{
        vincularClase(){
            const vincularSala = {
                Clase_id: this.clase_id,
                Professor_id : this.id
            };
            //console.log(vincularSala)
            axios.post('classeProfessor', vincularSala, {
                    headers: {
                    'Content-Type': 'application/json'
                    }
                })
                .then(response => {
                    console.log('vinculo salva com sucesso:', response.data);
                    location.reload();
                    this.dialog = false
                })
                .catch(error => {
                    console.error('Erro ao salvar a aluno:', error.message);
                    this.dialog = false
                });
        },
        vincularMateria(){
            const vincularMateria = {
                Materia_id: this.materia_id,
                Professor_id : this.id
            };
            //console.log(vincularSala)
            axios.post('ProfessorMateria', vincularMateria, {
                    headers: {
                    'Content-Type': 'application/json'
                    }
                })
                .then(response => {
                    console.log('vinculo salva com sucesso:', response.data);
                    location.reload();
                    this.modalMateria = false
                })
                .catch(error => {
                    console.error('Erro ao salvar a aluno:', error.message);
                    this.modalMateria = false
                });
        },
        async fetchSala() {
            try {
                const response = await axios.get('clases');
                //console.log(response.data); 
                this.salas = response.data;
            } catch (error) {
                console.error('Erro ao buscar clase:', error);
            }
        },
        async fetchMateria(){
            try {
                const response = await axios.get('materia');
                //console.log(response.data); 
                this.materias = response.data;
            } catch (error) {
                console.error('Erro ao buscar clase:', error);
            }
        },
        salaProps (salas) {
            return {
                title: salas.nome,
            }
        },
        materiaProps (materias) {
            return {
                title: materias.nome,
            }
        },
    }
}
</script>