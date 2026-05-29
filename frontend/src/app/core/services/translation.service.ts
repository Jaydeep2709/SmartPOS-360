import { Injectable } from '@angular/core';

import {
  TranslateService
} from '@ngx-translate/core';

import en from '../../i18n/en.json'

import es from '../../i18n/es.json';

import fr from '../../i18n/fr.json';

@Injectable({
  providedIn: 'root'
})
export class TranslationService {

  constructor(
    private translate: TranslateService
  ) {

    // LOAD TRANSLATIONS

    this.translate.setTranslation('en', en);

    this.translate.setTranslation('es', es);

    this.translate.setTranslation('fr', fr);

    // AVAILABLE LANGUAGES

    this.translate.addLangs([
      'en',
      'es',
      'fr'
    ]);

    // DEFAULT

    this.translate.setDefaultLang('en');

    // CURRENT LANGUAGE

    const savedLang =
      localStorage.getItem('lang') || 'en';

    this.translate.use(savedLang);
  }

  setLanguage(lang: string) {

    this.translate.use(lang);

    localStorage.setItem(
      'lang',
      lang
    );
  }

}