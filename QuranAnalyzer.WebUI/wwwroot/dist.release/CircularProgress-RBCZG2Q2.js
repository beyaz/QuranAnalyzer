import{a as n}from"./chunk-UG5D44MT.js";import{S as p,T as M,b as S,c as t,d as _,w as $,x as w,y as D}from"./chunk-KH7ZNKZE.js";import"./chunk-Z77M2RWE.js";import{a as V,m as i}from"./chunk-2JQQM347.js";import{a as K}from"./chunk-EMKQGYXC.js";import{e as b}from"./chunk-PU6LYOEU.js";var z=b(K());function R(r){return w("MuiCircularProgress",r)}var Q=D("MuiCircularProgress",["root","determinate","indeterminate","colorPrimary","colorSecondary","svg","circle","circleDeterminate","circleIndeterminate","circleDisableShrink"]);var m=b(V()),W=["className","color","disableShrink","size","style","thickness","value","variant"],f=r=>r,N,O,j,U,s=44,B=(0,i.keyframes)(N||(N=f`
  0% {
    transform: rotate(0deg);
  }

  100% {
    transform: rotate(360deg);
  }
`)),G=(0,i.keyframes)(O||(O=f`
  0% {
    stroke-dasharray: 1px, 200px;
    stroke-dashoffset: 0;
  }

  50% {
    stroke-dasharray: 100px, 200px;
    stroke-dashoffset: -15px;
  }

  100% {
    stroke-dasharray: 100px, 200px;
    stroke-dashoffset: -125px;
  }
`)),L=r=>{let{classes:e,variant:o,color:a,disableShrink:u}=r,d={root:["root",o,`color${n(a)}`],svg:["svg"],circle:["circle",`circle${n(o)}`,u&&"circleDisableShrink"]};return $(d,R,e)},Y=p("span",{name:"MuiCircularProgress",slot:"Root",overridesResolver:(r,e)=>{let{ownerState:o}=r;return[e.root,e[o.variant],e[`color${n(o.color)}`]]}})(({ownerState:r,theme:e})=>t({display:"inline-block"},r.variant==="determinate"&&{transition:e.transitions.create("transform")},r.color!=="inherit"&&{color:(e.vars||e).palette[r.color].main}),({ownerState:r})=>r.variant==="indeterminate"&&(0,i.css)(j||(j=f`
      animation: ${0} 1.4s linear infinite;
    `),B)),Z=p("svg",{name:"MuiCircularProgress",slot:"Svg",overridesResolver:(r,e)=>e.svg})({display:"block"}),q=p("circle",{name:"MuiCircularProgress",slot:"Circle",overridesResolver:(r,e)=>{let{ownerState:o}=r;return[e.circle,e[`circle${n(o.variant)}`],o.disableShrink&&e.circleDisableShrink]}})(({ownerState:r,theme:e})=>t({stroke:"currentColor"},r.variant==="determinate"&&{transition:e.transitions.create("stroke-dashoffset")},r.variant==="indeterminate"&&{strokeDasharray:"80px, 200px",strokeDashoffset:0}),({ownerState:r})=>r.variant==="indeterminate"&&!r.disableShrink&&(0,i.css)(U||(U=f`
      animation: ${0} 1.4s ease-in-out infinite;
    `),G)),A=z.forwardRef(function(e,o){let a=M({props:e,name:"MuiCircularProgress"}),{className:u,color:d="primary",disableShrink:E=!1,size:y=40,style:I,thickness:c=3.6,value:h=0,variant:T="indeterminate"}=a,F=S(a,W),l=t({},a,{color:d,disableShrink:E,size:y,thickness:c,value:h,variant:T}),P=L(l),g={},k={},x={};if(T==="determinate"){let C=2*Math.PI*((s-c)/2);g.strokeDasharray=C.toFixed(3),x["aria-valuenow"]=Math.round(h),g.strokeDashoffset=`${((100-h)/100*C).toFixed(3)}px`,k.transform="rotate(-90deg)"}return(0,m.jsx)(Y,t({className:_(P.root,u),style:t({width:y,height:y},k,I),ownerState:l,ref:o,role:"progressbar"},x,F,{children:(0,m.jsx)(Z,{className:P.svg,ownerState:l,viewBox:`${s/2} ${s/2} ${s} ${s}`,children:(0,m.jsx)(q,{className:P.circle,style:g,ownerState:l,cx:s,cy:s,r:(s-c)/2,fill:"none",strokeWidth:c})})}))}),v=A;var dr=v;export{dr as default};
