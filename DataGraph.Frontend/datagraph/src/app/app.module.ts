import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { DatagraphNodeComponent } from './datagraph-node/datagraph-node.component';
import { DatagraphViewComponent } from './datagraph-view/datagraph-view.component';

@NgModule({
  declarations: [
    AppComponent,
    DatagraphNodeComponent,
    DatagraphViewComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
