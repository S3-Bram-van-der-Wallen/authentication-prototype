import { initializeApp, getApps } from 'firebase/app';
import { getAuth } from 'firebase/auth';
import fs from 'fs';

// Read firebase_variables.json
const firebaseConfig = JSON.parse(fs.readFileSync('firebase_variables.json', 'utf8'));

// Initialize Firebase
let firebaseApp;

if (!getApps().length) {
  firebaseApp = initializeApp(firebaseConfig);
}

// Auth
const firebaseAuth = getAuth(firebaseApp);

export { firebaseApp, firebaseAuth };
