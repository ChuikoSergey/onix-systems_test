declare var LeaderLine: any;
declare var PlainDraggable: any;
import { Component } from '@angular/core';
import { DataSchemeDto } from 'src/model/data-scheme/dataSchemeDto';
import { DataSchemeService } from 'src/service/data-scheme/dataSheme.service';

@Component({
  selector: 'app-datagraph-view',
  templateUrl: './datagraph-view.component.html',
  styleUrls: ['./datagraph-view.component.css']
})
export class DatagraphViewComponent {
  dataScheme : DataSchemeDto = new DataSchemeDto({
    nodes: [],
    branches: []
  });

  lines: any[] = [];
  draggableItems: any[] = [];
  innerWidth: number = 0;
  marginTop: number = 50;

  constructor(private dataSchemeService: DataSchemeService) {
  }

  ngOnInit() {
    this.dataSchemeService.getDataScheme().subscribe(response => {
      this.dataScheme.nodes.push(...response.nodes);
      this.dataScheme.branches.push(...response.branches);
    });

    this.innerWidth = window.innerWidth;
  }

  refreshLines() {
    if (this.lines?.length) {
      this.lines.forEach(line => {
        line.remove();
      });
    }
    this.lines = [];
    this.dataScheme.branches.forEach(branch => {
      this.lines.push(new LeaderLine(
        document.getElementById(branch.fromNode),
        document.getElementById(branch.toNode),
        {
          middleLabel: LeaderLine.captionLabel(`Each ${branch.toNode} may have multiple ${branch.fromNode}`)
        }));
      });
  }

  refreshDraggableElements() {
    if(this.draggableItems?.length) {
      this.draggableItems.forEach(draggableItem => {
        draggableItem.remove();
      })
    }

    this.draggableItems = [];

    this.dataScheme.nodes.forEach(node => {
      const draggable = new PlainDraggable(
        document.getElementById(node.name)
      );
      draggable.containment = {left: 0, top: 0, width: '100%', height: '100%'};
      draggable.element.style.width = 'fit-content';
      draggable.onMove = () => this.refreshLines();
      this.draggableItems.push();
    });

    this.refreshLines();
  }

  ngOnDestroy() {
    if(this.draggableItems?.length) {
      this.draggableItems.forEach(draggableItem => {
        draggableItem.remove();
      })
    }

    if (this.lines?.length) {
      this.lines.forEach(line => {
        line.remove();
      });
    }
  }
}
