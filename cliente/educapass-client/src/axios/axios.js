import axios from "axios";
import Cookies from 'js-cookie';

const token = Cookies.get('escola_token')
axios.defaults.baseURL = "https://localhost:57741/api/";
axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;