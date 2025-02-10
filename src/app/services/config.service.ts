import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  readonly ApiUrl = 'http://localhost:5283';
  constructor() { }
}
