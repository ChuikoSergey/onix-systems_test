declare var LeaderLine: any;
declare var PlainDraggable: any;
import { Component } from '@angular/core';
import { DataSchemeDto } from 'src/model/data-scheme/dtos/dataSchemeDto';
import { DataSchemeService } from 'src/service/data-scheme/dataSheme.service';
import jsPDF  from 'jspdf';
import * as htmlToImage from 'html-to-image';

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
          middleLabel: `Each ${branch.toNode} may have multiple ${branch.fromNode}`
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

  exportToPdf() {
    const width = window.innerWidth;
    const height = window.innerHeight;
    this.hideNonGraphElements();
    htmlToImage.toPng(document.getElementsByTagName('body')[0], {
      width: width,
      height: height
    }).then(result => {
      const pdf = new jsPDF({
        orientation: 'l',
        unit: 'pt',
        format: [width, height]
      });

      // Drawing lines manually because jsPdf can't handle svg elements
      this.lines.forEach(line => {
        const start = line.start.getBoundingClientRect();
        const end = line.end.getBoundingClientRect();
        const startCenter = {
          x : start.x + (start.width / 2),
          y: start.y + (start.height / 2)
        };
        const endCenter = {
          x : end.x + (end.width / 2),
          y: end.y + (end.height / 2)
        };
        pdf.setDrawColor('coral');
        pdf.setTextColor('coral');
        pdf.line(startCenter.x, startCenter.y, endCenter.x, endCenter.y, 'S');
        pdf.text(line.middleLabel, (startCenter.x + endCenter.x) / 2, (startCenter.y + endCenter.y) / 2, {
          align: 'center'
        });
      })

      pdf.addImage(result, 'PNG', 0, 0, width, height);
      pdf.save('file_name'+ '.pdf');
      this.showNonGraphElements();
    });
  }

  hideNonGraphElements() {
    document.getElementById('input-container')!.style.display = 'none';
    const svgTexts = document.getElementsByTagName('text');
    for (let i = 0; i < svgTexts.length; i++) {
      svgTexts[i].style.display = 'none';
    }
  }

  showNonGraphElements() {
    document.getElementById('input-container')!.style.display = 'block';
    const svgTexts = document.getElementsByTagName('text');
    for (let i = 0; i < svgTexts.length; i++) {
      svgTexts[i].style.display = 'block';
    }
  }

  buildDataGraph(connectionString: string) {
    if(connectionString?.length)
    {
      this.disposeCurrentGraph();

      this.dataSchemeService.getDataScheme(connectionString).subscribe(response => {
        this.dataScheme.nodes.push(...response.nodes);
        this.dataScheme.branches.push(...response.branches);
      });
    }
  }

  disposeCurrentGraph() {
    if (this.lines?.length) {
      this.lines.forEach(line => {
        line.remove();
      });
    }

    if(this.draggableItems?.length) {
      this.draggableItems.forEach(draggableItem => {
        draggableItem.remove();
      })
    }

    this.draggableItems = [];
    this.lines = [];
    this.dataScheme.nodes = [];
    this.dataScheme.branches = [];
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
