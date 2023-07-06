import { Component } from '@angular/core';
import { CalculationService } from './calculation.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private calculationService: CalculationService) {}

  title = 'scenius-codetest';
  calculation = '';
  result: Number = 0;
  calculationResults: Observable<CalculationResult[]> = this.calculationService.getCalculations();

  doCalculation() {
    this.calculationService.doCalculation(this.calculation).subscribe(res => {
      this.result = res.result;
    },
    () => {
      // Dit is error
    })
  }
}

export interface CalculationResult {
  id: Number;
  rawCalculation: string;
  result: Number;
}
