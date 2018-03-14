import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ModuleWithProviders, NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';

import { OnEnterPressDirective } from '@app/directives';
import { MaterialModule } from './material.module';
import { JoinPipe } from '@app/pipes';

import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { AuthErrorInterceptor, JWTInterceptor } from '@app/interceptors/';

import { AuthGuard } from '@app/guards';
import { AuthService } from '@app/services';

@NgModule({
  imports: [],
  declarations: [JoinPipe, OnEnterPressDirective],
  exports: [
    CommonModule,
    RouterModule,
    HttpModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    MaterialModule,
    TranslateModule,
    JoinPipe,
    OnEnterPressDirective
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthErrorInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JWTInterceptor,
      multi: true
    },
    AuthGuard,
    AuthService
  ]
})
export class SharedModule {
  public static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: []
    };
  }
}
