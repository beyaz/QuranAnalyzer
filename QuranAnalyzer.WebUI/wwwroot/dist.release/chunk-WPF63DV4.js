import{a as y}from"./chunk-UG5D44MT.js";import{J as x,S as v,T as C,b as u,c as p,d as T,w as d,x as b,y as P}from"./chunk-KH7ZNKZE.js";import{a as E}from"./chunk-2JQQM347.js";import{a as D}from"./chunk-EMKQGYXC.js";import{e as f}from"./chunk-PU6LYOEU.js";var j=f(D());function B(r){return b("MuiTypography",r)}var F=P("MuiTypography",["root","h1","h2","h3","h4","h5","h6","subtitle1","subtitle2","body1","body2","inherit","button","caption","overline","alignLeft","alignRight","alignCenter","alignJustify","noWrap","gutterBottom","paragraph"]);var M=f(E()),L=["align","className","component","gutterBottom","noWrap","paragraph","variant","variantMapping"],V=r=>{let{align:o,gutterBottom:t,noWrap:a,paragraph:s,variant:e,classes:i}=r,n={root:["root",e,r.align!=="inherit"&&`align${y(o)}`,t&&"gutterBottom",a&&"noWrap",s&&"paragraph"]};return d(n,B,i)},$=v("span",{name:"MuiTypography",slot:"Root",overridesResolver:(r,o)=>{let{ownerState:t}=r;return[o.root,t.variant&&o[t.variant],t.align!=="inherit"&&o[`align${y(t.align)}`],t.noWrap&&o.noWrap,t.gutterBottom&&o.gutterBottom,t.paragraph&&o.paragraph]}})(({theme:r,ownerState:o})=>p({margin:0},o.variant&&r.typography[o.variant],o.align!=="inherit"&&{textAlign:o.align},o.noWrap&&{overflow:"hidden",textOverflow:"ellipsis",whiteSpace:"nowrap"},o.gutterBottom&&{marginBottom:"0.35em"},o.paragraph&&{marginBottom:16})),W={h1:"h1",h2:"h2",h3:"h3",h4:"h4",h5:"h5",h6:"h6",subtitle1:"h6",subtitle2:"h6",body1:"p",body2:"p",inherit:"p"},w={primary:"primary.main",textPrimary:"text.primary",secondary:"secondary.main",textSecondary:"text.secondary",error:"error.main"},z=r=>w[r]||r,A=j.forwardRef(function(o,t){let a=C({props:o,name:"MuiTypography"}),s=z(a.color),e=x(p({},a,{color:s})),{align:i="inherit",className:n,component:m,gutterBottom:O=!1,noWrap:_=!1,paragraph:h=!1,variant:l="body1",variantMapping:g=W}=e,R=u(e,L),c=p({},e,{align:i,color:s,className:n,component:m,gutterBottom:O,noWrap:_,paragraph:h,variant:l,variantMapping:g}),N=m||(h?"p":g[l]||W[l])||"span",U=V(c);return(0,M.jsx)($,p({as:N,ref:t,ownerState:c,className:T(U.root,n)},R))}),J=A;export{J as a};
