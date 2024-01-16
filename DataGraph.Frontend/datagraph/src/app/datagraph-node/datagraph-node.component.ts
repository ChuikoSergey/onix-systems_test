import { Component, Input, Output, EventEmitter } from '@angular/core';
import { DataSchemeNodeDto } from 'src/model/data-scheme/dtos/dataSchemeNodeDto';

@Component({
  selector: 'app-datagraph-node',
  templateUrl: './datagraph-node.component.html',
  styleUrls: ['./datagraph-node.component.css']
})
export class DatagraphNodeComponent {
  @Input() node: DataSchemeNodeDto = new DataSchemeNodeDto({});
  @Input() isLast: boolean = false;
  @Output() norifyLastInit: EventEmitter<any> = new EventEmitter();

  ngAfterViewInit() {
    if (this.isLast) {
      this.norifyLastInit.emit();
    }
  }
}
