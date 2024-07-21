import{a as nt}from"./chunk-H2TPGIJH.js";import{a as ot,b as it,d as mt,e as ft,f as ct,g as lt,h as pt,i as dt,j as yt,k as ut,m as t}from"./chunk-2JQQM347.js";import{a as h}from"./chunk-EMKQGYXC.js";import{a as p,b as R,c as j,d as F,e as u}from"./chunk-PU6LYOEU.js";var P=F(B=>{"use strict";Object.defineProperty(B,"__esModule",{value:!0});var Ot=ot(),Y=ut();h();ft();it();mt();lt();ct();pt();dt();yt();function wt(r){if(r&&r.__esModule)return r;var e=Object.create(null);return r&&Object.keys(r).forEach(function(a){if(a!=="default"){var s=Object.getOwnPropertyDescriptor(r,a);Object.defineProperty(e,a,s.get?s:{enumerable:!0,get:function(){return r[a]}})}}),e.default=r,Object.freeze(e)}var V=wt(Ot),jt=V.Fragment;function It(r,e,a){return Y.hasOwnProperty.call(e,"css")?V.jsx(Y.Emotion,Y.createEmotionProps(r,e),a):V.jsx(r,e,a)}function Rt(r,e,a){return Y.hasOwnProperty.call(e,"css")?V.jsxs(Y.Emotion,Y.createEmotionProps(r,e),a):V.jsxs(r,e,a)}B.Fragment=jt;B.jsx=It;B.jsxs=Rt});var W=F((ve,J)=>{"use strict";J.exports=P()});var H=u(h(),1);var X=u(h(),1);var g=u(h(),1);function _(){return _=Object.assign||function(r){for(var e=1;e<arguments.length;e++){var a=arguments[e];for(var s in a)Object.prototype.hasOwnProperty.call(a,s)&&(r[s]=a[s])}return r},_.apply(this,arguments)}function gt(r,e){if(r==null)return{};var a={},s=Object.keys(r),i,o;for(o=0;o<s.length;o++)i=s[o],!(e.indexOf(i)>=0)&&(a[i]=r[i]);return a}var U=new Map,N=new WeakMap,T=0,kt;function ht(r){return r?(N.has(r)||(T+=1,N.set(r,T.toString())),N.get(r)):"0"}function vt(r){return Object.keys(r).sort().filter(e=>r[e]!==void 0).map(e=>`${e}_${e==="root"?ht(r.root):r[e]}`).toString()}function bt(r){let e=vt(r),a=U.get(e);if(!a){let s=new Map,i,o=new IntersectionObserver(m=>{m.forEach(f=>{var l;let k=f.isIntersecting&&i.some(y=>f.intersectionRatio>=y);r.trackVisibility&&typeof f.isVisible=="undefined"&&(f.isVisible=k),(l=s.get(f.target))==null||l.forEach(y=>{y(k,f)})})},r);i=o.thresholds||(Array.isArray(r.threshold)?r.threshold:[r.threshold||0]),a={id:e,observer:o,elements:s},U.set(e,a)}return a}function A(r,e,a={},s=kt){if(typeof window.IntersectionObserver=="undefined"&&s!==void 0){let l=r.getBoundingClientRect();return e(s,{isIntersecting:s,target:r,intersectionRatio:typeof a.threshold=="number"?a.threshold:0,time:0,boundingClientRect:l,intersectionRect:l,rootBounds:l}),()=>{}}let{id:i,observer:o,elements:m}=bt(a),f=m.get(r)||[];return m.has(r)||m.set(r,f),f.push(e),o.observe(r),function(){f.splice(f.indexOf(e),1),f.length===0&&(m.delete(r),o.unobserve(r)),m.size===0&&(o.disconnect(),U.delete(i))}}var xt=["children","as","triggerOnce","threshold","root","rootMargin","onChange","skip","trackVisibility","delay","initialInView","fallbackInView"];function $(r){return typeof r.children!="function"}var M=class extends g.Component{constructor(e){super(e),this.node=null,this._unobserveCb=null,this.handleNode=a=>{this.node&&(this.unobserve(),!a&&!this.props.triggerOnce&&!this.props.skip&&this.setState({inView:!!this.props.initialInView,entry:void 0})),this.node=a||null,this.observeNode()},this.handleChange=(a,s)=>{a&&this.props.triggerOnce&&this.unobserve(),$(this.props)||this.setState({inView:a,entry:s}),this.props.onChange&&this.props.onChange(a,s)},this.state={inView:!!e.initialInView,entry:void 0}}componentDidUpdate(e){(e.rootMargin!==this.props.rootMargin||e.root!==this.props.root||e.threshold!==this.props.threshold||e.skip!==this.props.skip||e.trackVisibility!==this.props.trackVisibility||e.delay!==this.props.delay)&&(this.unobserve(),this.observeNode())}componentWillUnmount(){this.unobserve(),this.node=null}observeNode(){if(!this.node||this.props.skip)return;let{threshold:e,root:a,rootMargin:s,trackVisibility:i,delay:o,fallbackInView:m}=this.props;this._unobserveCb=A(this.node,this.handleChange,{threshold:e,root:a,rootMargin:s,trackVisibility:i,delay:o},m)}unobserve(){this._unobserveCb&&(this._unobserveCb(),this._unobserveCb=null)}render(){if(!$(this.props)){let{inView:o,entry:m}=this.state;return this.props.children({inView:o,entry:m,ref:this.handleNode})}let e=this.props,{children:a,as:s}=e,i=gt(e,xt);return g.createElement(s||"div",_({ref:this.handleNode},i),a)}};function E({threshold:r,delay:e,trackVisibility:a,rootMargin:s,root:i,triggerOnce:o,skip:m,initialInView:f,fallbackInView:l,onChange:k}={}){var y;let[O,w]=g.useState(null),I=g.useRef(),[v,c]=g.useState({inView:!!f,entry:void 0});I.current=k,g.useEffect(()=>{if(m||!O)return;let b;return b=A(O,(z,L)=>{c({inView:z,entry:L}),I.current&&I.current(z,L),L.isIntersecting&&o&&b&&(b(),b=void 0)},{root:i,rootMargin:s,threshold:r,trackVisibility:a,delay:e},l),()=>{b&&b()}},[Array.isArray(r)?r.toString():r,O,i,s,o,m,a,l,e]);let S=(y=v.entry)==null?void 0:y.target,C=g.useRef();!O&&S&&!o&&!m&&C.current!==S&&(C.current=S,c({inView:!!f,entry:void 0}));let d=[w,v.inView,v.entry];return d.ref=d[0],d.inView=d[1],d.entry=d[2],d}var K=u(nt(),1);var n=u(W(),1);var Q=u(h(),1);var tt=u(h(),1);var rt=u(h(),1);var Ur=u(h(),1);var et=u(h(),1);var at=u(h(),1);var st=u(h(),1);var zt=t.keyframes`
  from,
  20%,
  53%,
  to {
    animation-timing-function: cubic-bezier(0.215, 0.61, 0.355, 1);
    transform: translate3d(0, 0, 0);
  }

  40%,
  43% {
    animation-timing-function: cubic-bezier(0.755, 0.05, 0.855, 0.06);
    transform: translate3d(0, -30px, 0) scaleY(1.1);
  }

  70% {
    animation-timing-function: cubic-bezier(0.755, 0.05, 0.855, 0.06);
    transform: translate3d(0, -15px, 0) scaleY(1.05);
  }

  80% {
    transition-timing-function: cubic-bezier(0.215, 0.61, 0.355, 1);
    transform: translate3d(0, 0, 0) scaleY(0.95);
  }

  90% {
    transform: translate3d(0, -4px, 0) scaleY(1.02);
  }
`,Yt=t.keyframes`
  from,
  50%,
  to {
    opacity: 1;
  }

  25%,
  75% {
    opacity: 0;
  }
`,Xt=t.keyframes`
  0% {
    transform: translateX(0);
  }

  6.5% {
    transform: translateX(-6px) rotateY(-9deg);
  }

  18.5% {
    transform: translateX(5px) rotateY(7deg);
  }

  31.5% {
    transform: translateX(-3px) rotateY(-5deg);
  }

  43.5% {
    transform: translateX(2px) rotateY(3deg);
  }

  50% {
    transform: translateX(0);
  }
`,St=t.keyframes`
  0% {
    transform: scale(1);
  }

  14% {
    transform: scale(1.3);
  }

  28% {
    transform: scale(1);
  }

  42% {
    transform: scale(1.3);
  }

  70% {
    transform: scale(1);
  }
`,Ct=t.keyframes`
  from,
  11.1%,
  to {
    transform: translate3d(0, 0, 0);
  }

  22.2% {
    transform: skewX(-12.5deg) skewY(-12.5deg);
  }

  33.3% {
    transform: skewX(6.25deg) skewY(6.25deg);
  }

  44.4% {
    transform: skewX(-3.125deg) skewY(-3.125deg);
  }

  55.5% {
    transform: skewX(1.5625deg) skewY(1.5625deg);
  }

  66.6% {
    transform: skewX(-0.78125deg) skewY(-0.78125deg);
  }

  77.7% {
    transform: skewX(0.390625deg) skewY(0.390625deg);
  }

  88.8% {
    transform: skewX(-0.1953125deg) skewY(-0.1953125deg);
  }
`,Mt=t.keyframes`
  from {
    transform: scale3d(1, 1, 1);
  }

  50% {
    transform: scale3d(1.05, 1.05, 1.05);
  }

  to {
    transform: scale3d(1, 1, 1);
  }
`,Vt=t.keyframes`
  from {
    transform: scale3d(1, 1, 1);
  }

  30% {
    transform: scale3d(1.25, 0.75, 1);
  }

  40% {
    transform: scale3d(0.75, 1.25, 1);
  }

  50% {
    transform: scale3d(1.15, 0.85, 1);
  }

  65% {
    transform: scale3d(0.95, 1.05, 1);
  }

  75% {
    transform: scale3d(1.05, 0.95, 1);
  }

  to {
    transform: scale3d(1, 1, 1);
  }
`,Bt=t.keyframes`
  from,
  to {
    transform: translate3d(0, 0, 0);
  }

  10%,
  30%,
  50%,
  70%,
  90% {
    transform: translate3d(-10px, 0, 0);
  }

  20%,
  40%,
  60%,
  80% {
    transform: translate3d(10px, 0, 0);
  }
`,Nt=t.keyframes`
  from,
  to {
    transform: translate3d(0, 0, 0);
  }

  10%,
  30%,
  50%,
  70%,
  90% {
    transform: translate3d(-10px, 0, 0);
  }

  20%,
  40%,
  60%,
  80% {
    transform: translate3d(10px, 0, 0);
  }
`,Dt=t.keyframes`
  from,
  to {
    transform: translate3d(0, 0, 0);
  }

  10%,
  30%,
  50%,
  70%,
  90% {
    transform: translate3d(0, -10px, 0);
  }

  20%,
  40%,
  60%,
  80% {
    transform: translate3d(0, 10px, 0);
  }
`,Lt=t.keyframes`
  20% {
    transform: rotate3d(0, 0, 1, 15deg);
  }

  40% {
    transform: rotate3d(0, 0, 1, -10deg);
  }

  60% {
    transform: rotate3d(0, 0, 1, 5deg);
  }

  80% {
    transform: rotate3d(0, 0, 1, -5deg);
  }

  to {
    transform: rotate3d(0, 0, 1, 0deg);
  }
`,_t=t.keyframes`
  from {
    transform: scale3d(1, 1, 1);
  }

  10%,
  20% {
    transform: scale3d(0.9, 0.9, 0.9) rotate3d(0, 0, 1, -3deg);
  }

  30%,
  50%,
  70%,
  90% {
    transform: scale3d(1.1, 1.1, 1.1) rotate3d(0, 0, 1, 3deg);
  }

  40%,
  60%,
  80% {
    transform: scale3d(1.1, 1.1, 1.1) rotate3d(0, 0, 1, -3deg);
  }

  to {
    transform: scale3d(1, 1, 1);
  }
`,Ut=t.keyframes`
  from {
    transform: translate3d(0, 0, 0);
  }

  15% {
    transform: translate3d(-25%, 0, 0) rotate3d(0, 0, 1, -5deg);
  }

  30% {
    transform: translate3d(20%, 0, 0) rotate3d(0, 0, 1, 3deg);
  }

  45% {
    transform: translate3d(-15%, 0, 0) rotate3d(0, 0, 1, -3deg);
  }

  60% {
    transform: translate3d(10%, 0, 0) rotate3d(0, 0, 1, 2deg);
  }

  75% {
    transform: translate3d(-5%, 0, 0) rotate3d(0, 0, 1, -1deg);
  }

  to {
    transform: translate3d(0, 0, 0);
  }
`,Et=t.keyframes`
  from {
    opacity: 0;
  }

  to {
    opacity: 1;
  }
`,qt=t.keyframes`
  from {
    opacity: 0;
    transform: translate3d(-100%, 100%, 0);
  }

  to {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }
`,Ft=t.keyframes`
  from {
    opacity: 0;
    transform: translate3d(100%, 100%, 0);
  }

  to {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }
`,Tt=t.keyframes`
  from {
    opacity: 0;
    transform: translate3d(0, -100%, 0);
  }

  to {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }
`,$t=t.keyframes`
  from {
    opacity: 0;
    transform: translate3d(0, -2000px, 0);
  }

  to {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }
`,q=t.keyframes`
  from {
    opacity: 0;
    transform: translate3d(-100%, 0, 0);
  }

  to {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }
`,At=t.keyframes`
  from {
    opacity: 0;
    transform: translate3d(-2000px, 0, 0);
  }

  to {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }
`,Pt=t.keyframes`
  from {
    opacity: 0;
    transform: translate3d(100%, 0, 0);
  }

  to {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }
`,Jt=t.keyframes`
  from {
    opacity: 0;
    transform: translate3d(2000px, 0, 0);
  }

  to {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }
`,Wt=t.keyframes`
  from {
    opacity: 0;
    transform: translate3d(-100%, -100%, 0);
  }

  to {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }
`,Ht=t.keyframes`
  from {
    opacity: 0;
    transform: translate3d(100%, -100%, 0);
  }

  to {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }
`,Kt=t.keyframes`
  from {
    opacity: 0;
    transform: translate3d(0, 100%, 0);
  }

  to {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }
`,Zt=t.keyframes`
  from {
    opacity: 0;
    transform: translate3d(0, 2000px, 0);
  }

  to {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }
`;function Gt({duration:r=1e3,delay:e=0,timingFunction:a="ease",keyframes:s=q,iterationCount:i=1}){return t.css`
    animation-duration: ${r}ms;
    animation-timing-function: ${a};
    animation-delay: ${e}ms;
    animation-name: ${s};
    animation-direction: normal;
    animation-fill-mode: both;
    animation-iteration-count: ${i};

    @media (prefers-reduced-motion: reduce) {
      animation: none;
    }
  `}function Qt(r){return r==null}function tr(r){return typeof r=="string"||typeof r=="number"||typeof r=="boolean"}function Z(r,e){return a=>a?r():e()}function D(r){return Z(r,()=>null)}var x=r=>{let{cascade:e=!1,damping:a=.5,delay:s=0,duration:i=1e3,fraction:o=0,keyframes:m=q,triggerOnce:f=!1,className:l,style:k,childClassName:y,childStyle:O,children:w,onVisibilityChange:I}=r,v=(0,X.useMemo)(()=>Gt({keyframes:m,duration:i}),[i,m]);return Qt(w)?null:tr(w)?(0,n.jsx)(er,R(p({},r),{animationStyles:v,children:String(w)})):(0,K.isFragment)(w)?(0,n.jsx)(G,R(p({},r),{animationStyles:v})):(0,n.jsx)(n.Fragment,{children:X.Children.map(w,(c,S)=>{if(!(0,X.isValidElement)(c))return null;let C=s+(e?S*i*a:0);switch(c.type){case"ol":case"ul":return(0,n.jsx)(t.ClassNames,{children:({cx:d})=>(0,n.jsx)(c.type,R(p({},c.props),{className:d(l,c.props.className),style:Object.assign({},k,c.props.style),children:(0,n.jsx)(x,R(p({},r),{children:c.props.children}))}))});case"li":return(0,n.jsx)(M,{threshold:o,triggerOnce:f,onChange:I,children:({inView:d,ref:b})=>(0,n.jsx)(t.ClassNames,{children:({cx:z})=>(0,n.jsx)(c.type,R(p({},c.props),{ref:b,className:z(y,c.props.className),css:D(()=>v)(d),style:Object.assign({},O,c.props.style,{animationDelay:C+"ms"})}))})});default:return(0,n.jsx)(M,{threshold:o,triggerOnce:f,onChange:I,children:({inView:d,ref:b})=>(0,n.jsx)("div",{ref:b,className:l,css:D(()=>v)(d),style:Object.assign({},k,{animationDelay:C+"ms"}),children:(0,n.jsx)(t.ClassNames,{children:({cx:z})=>(0,n.jsx)(c.type,R(p({},c.props),{className:z(y,c.props.className),style:Object.assign({},O,c.props.style)}))})})})}})})},rr={display:"inline-block",whiteSpace:"pre"},er=r=>{let{animationStyles:e,cascade:a=!1,damping:s=.5,delay:i=0,duration:o=1e3,fraction:m=0,triggerOnce:f=!1,className:l,style:k,children:y,onVisibilityChange:O}=r,{ref:w,inView:I}=E({triggerOnce:f,threshold:m,onChange:O});return Z(()=>(0,n.jsx)("div",{ref:w,className:l,style:Object.assign({},k,rr),children:y.split("").map((v,c)=>(0,n.jsx)("span",{css:D(()=>e)(I),style:{animationDelay:i+c*o*s+"ms"},children:v},c))}),()=>(0,n.jsx)(G,R(p({},r),{children:y})))(a)},G=r=>{let{animationStyles:e,fraction:a=0,triggerOnce:s=!1,className:i,style:o,children:m,onVisibilityChange:f}=r,{ref:l,inView:k}=E({triggerOnce:s,threshold:a,onChange:f});return(0,n.jsx)("div",{ref:l,className:i,css:D(()=>e)(k),style:o,children:m})};function ar(r){switch(r){case"bounce":return[zt,{transformOrigin:"center bottom"}];case"flash":return[Yt];case"headShake":return[Xt,{animationTimingFunction:"ease-in-out"}];case"heartBeat":return[St,{animationTimingFunction:"ease-in-out"}];case"jello":return[Ct,{transformOrigin:"center"}];case"pulse":return[Mt,{animationTimingFunction:"ease-in-out"}];case"rubberBand":return[Vt];case"shake":return[Bt];case"shakeX":return[Nt];case"shakeY":return[Dt];case"swing":return[Lt,{transformOrigin:"top center"}];case"tada":return[_t];case"wobble":return[Ut]}}var Ge=r=>{let m=r,{effect:e="bounce",style:a}=m,s=j(m,["effect","style"]),[i,o]=(0,H.useMemo)(()=>ar(e),[e]);return(0,n.jsx)(x,p({keyframes:i,style:Object.assign({},a,o)},s))},sr=t.keyframes`
  from,
  20%,
  40%,
  60%,
  80%,
  to {
    animation-timing-function: cubic-bezier(0.215, 0.61, 0.355, 1);
  }

  0% {
    opacity: 0;
    transform: scale3d(0.3, 0.3, 0.3);
  }

  20% {
    transform: scale3d(1.1, 1.1, 1.1);
  }

  40% {
    transform: scale3d(0.9, 0.9, 0.9);
  }

  60% {
    opacity: 1;
    transform: scale3d(1.03, 1.03, 1.03);
  }

  80% {
    transform: scale3d(0.97, 0.97, 0.97);
  }

  to {
    opacity: 1;
    transform: scale3d(1, 1, 1);
  }
`,or=t.keyframes`
  from,
  60%,
  75%,
  90%,
  to {
    animation-timing-function: cubic-bezier(0.215, 0.61, 0.355, 1);
  }

  0% {
    opacity: 0;
    transform: translate3d(0, -3000px, 0) scaleY(3);
  }

  60% {
    opacity: 1;
    transform: translate3d(0, 25px, 0) scaleY(0.9);
  }

  75% {
    transform: translate3d(0, -10px, 0) scaleY(0.95);
  }

  90% {
    transform: translate3d(0, 5px, 0) scaleY(0.985);
  }

  to {
    transform: translate3d(0, 0, 0);
  }
`,nr=t.keyframes`
  from,
  60%,
  75%,
  90%,
  to {
    animation-timing-function: cubic-bezier(0.215, 0.61, 0.355, 1);
  }

  0% {
    opacity: 0;
    transform: translate3d(-3000px, 0, 0) scaleX(3);
  }

  60% {
    opacity: 1;
    transform: translate3d(25px, 0, 0) scaleX(1);
  }

  75% {
    transform: translate3d(-10px, 0, 0) scaleX(0.98);
  }

  90% {
    transform: translate3d(5px, 0, 0) scaleX(0.995);
  }

  to {
    transform: translate3d(0, 0, 0);
  }
`,ir=t.keyframes`
  from,
  60%,
  75%,
  90%,
  to {
    animation-timing-function: cubic-bezier(0.215, 0.61, 0.355, 1);
  }

  from {
    opacity: 0;
    transform: translate3d(3000px, 0, 0) scaleX(3);
  }

  60% {
    opacity: 1;
    transform: translate3d(-25px, 0, 0) scaleX(1);
  }

  75% {
    transform: translate3d(10px, 0, 0) scaleX(0.98);
  }

  90% {
    transform: translate3d(-5px, 0, 0) scaleX(0.995);
  }

  to {
    transform: translate3d(0, 0, 0);
  }
`,mr=t.keyframes`
  from,
  60%,
  75%,
  90%,
  to {
    animation-timing-function: cubic-bezier(0.215, 0.61, 0.355, 1);
  }

  from {
    opacity: 0;
    transform: translate3d(0, 3000px, 0) scaleY(5);
  }

  60% {
    opacity: 1;
    transform: translate3d(0, -20px, 0) scaleY(0.9);
  }

  75% {
    transform: translate3d(0, 10px, 0) scaleY(0.95);
  }

  90% {
    transform: translate3d(0, -5px, 0) scaleY(0.985);
  }

  to {
    transform: translate3d(0, 0, 0);
  }
`,fr=t.keyframes`
  20% {
    transform: scale3d(0.9, 0.9, 0.9);
  }

  50%,
  55% {
    opacity: 1;
    transform: scale3d(1.1, 1.1, 1.1);
  }

  to {
    opacity: 0;
    transform: scale3d(0.3, 0.3, 0.3);
  }
`,cr=t.keyframes`
  20% {
    transform: translate3d(0, 10px, 0) scaleY(0.985);
  }

  40%,
  45% {
    opacity: 1;
    transform: translate3d(0, -20px, 0) scaleY(0.9);
  }

  to {
    opacity: 0;
    transform: translate3d(0, 2000px, 0) scaleY(3);
  }
`,lr=t.keyframes`
  20% {
    opacity: 1;
    transform: translate3d(20px, 0, 0) scaleX(0.9);
  }

  to {
    opacity: 0;
    transform: translate3d(-2000px, 0, 0) scaleX(2);
  }
`,pr=t.keyframes`
  20% {
    opacity: 1;
    transform: translate3d(-20px, 0, 0) scaleX(0.9);
  }

  to {
    opacity: 0;
    transform: translate3d(2000px, 0, 0) scaleX(2);
  }
`,dr=t.keyframes`
  20% {
    transform: translate3d(0, -10px, 0) scaleY(0.985);
  }

  40%,
  45% {
    opacity: 1;
    transform: translate3d(0, 20px, 0) scaleY(0.9);
  }

  to {
    opacity: 0;
    transform: translate3d(0, -2000px, 0) scaleY(3);
  }
`;function yr(r,e){switch(e){case"down":return r?cr:or;case"left":return r?lr:nr;case"right":return r?pr:ir;case"up":return r?dr:mr;default:return r?fr:sr}}var ca=r=>{let o=r,{direction:e,reverse:a=!1}=o,s=j(o,["direction","reverse"]),i=(0,Q.useMemo)(()=>yr(a,e),[e,a]);return(0,n.jsx)(x,p({keyframes:i},s))},ur=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    opacity: 0;
  }
`,gr=t.keyframes`
  from {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }

  to {
    opacity: 0;
    transform: translate3d(-100%, 100%, 0);
  }
`,kr=t.keyframes`
  from {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }

  to {
    opacity: 0;
    transform: translate3d(100%, 100%, 0);
  }
`,hr=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    opacity: 0;
    transform: translate3d(0, 100%, 0);
  }
`,vr=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    opacity: 0;
    transform: translate3d(0, 2000px, 0);
  }
`,br=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    opacity: 0;
    transform: translate3d(-100%, 0, 0);
  }
`,xr=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    opacity: 0;
    transform: translate3d(-2000px, 0, 0);
  }
`,Or=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    opacity: 0;
    transform: translate3d(100%, 0, 0);
  }
`,wr=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    opacity: 0;
    transform: translate3d(2000px, 0, 0);
  }
`,jr=t.keyframes`
  from {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }

  to {
    opacity: 0;
    transform: translate3d(-100%, -100%, 0);
  }
`,Ir=t.keyframes`
  from {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }

  to {
    opacity: 0;
    transform: translate3d(100%, -100%, 0);
  }
`,Rr=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    opacity: 0;
    transform: translate3d(0, -100%, 0);
  }
`,zr=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    opacity: 0;
    transform: translate3d(0, -2000px, 0);
  }
`;function Yr(r,e,a){switch(a){case"bottom-left":return e?gr:qt;case"bottom-right":return e?kr:Ft;case"down":return r?e?vr:$t:e?hr:Tt;case"left":return r?e?xr:At:e?br:q;case"right":return r?e?wr:Jt:e?Or:Pt;case"top-left":return e?jr:Wt;case"top-right":return e?Ir:Ht;case"up":return r?e?zr:Zt:e?Rr:Kt;default:return e?ur:Et}}var Ia=r=>{let m=r,{big:e=!1,direction:a,reverse:s=!1}=m,i=j(m,["big","direction","reverse"]),o=(0,tt.useMemo)(()=>Yr(e,s,a),[e,a,s]);return(0,n.jsx)(x,p({keyframes:o},i))},Xr=t.keyframes`
  from {
    transform: perspective(400px) scale3d(1, 1, 1) translate3d(0, 0, 0) rotate3d(0, 1, 0, -360deg);
    animation-timing-function: ease-out;
  }

  40% {
    transform: perspective(400px) scale3d(1, 1, 1) translate3d(0, 0, 150px)
      rotate3d(0, 1, 0, -190deg);
    animation-timing-function: ease-out;
  }

  50% {
    transform: perspective(400px) scale3d(1, 1, 1) translate3d(0, 0, 150px)
      rotate3d(0, 1, 0, -170deg);
    animation-timing-function: ease-in;
  }

  80% {
    transform: perspective(400px) scale3d(0.95, 0.95, 0.95) translate3d(0, 0, 0)
      rotate3d(0, 1, 0, 0deg);
    animation-timing-function: ease-in;
  }

  to {
    transform: perspective(400px) scale3d(1, 1, 1) translate3d(0, 0, 0) rotate3d(0, 1, 0, 0deg);
    animation-timing-function: ease-in;
  }
`,Sr=t.keyframes`
  from {
    transform: perspective(400px) rotate3d(1, 0, 0, 90deg);
    animation-timing-function: ease-in;
    opacity: 0;
  }

  40% {
    transform: perspective(400px) rotate3d(1, 0, 0, -20deg);
    animation-timing-function: ease-in;
  }

  60% {
    transform: perspective(400px) rotate3d(1, 0, 0, 10deg);
    opacity: 1;
  }

  80% {
    transform: perspective(400px) rotate3d(1, 0, 0, -5deg);
  }

  to {
    transform: perspective(400px);
  }
`,Cr=t.keyframes`
  from {
    transform: perspective(400px) rotate3d(0, 1, 0, 90deg);
    animation-timing-function: ease-in;
    opacity: 0;
  }

  40% {
    transform: perspective(400px) rotate3d(0, 1, 0, -20deg);
    animation-timing-function: ease-in;
  }

  60% {
    transform: perspective(400px) rotate3d(0, 1, 0, 10deg);
    opacity: 1;
  }

  80% {
    transform: perspective(400px) rotate3d(0, 1, 0, -5deg);
  }

  to {
    transform: perspective(400px);
  }
`,Mr=t.keyframes`
  from {
    transform: perspective(400px);
  }

  30% {
    transform: perspective(400px) rotate3d(1, 0, 0, -20deg);
    opacity: 1;
  }

  to {
    transform: perspective(400px) rotate3d(1, 0, 0, 90deg);
    opacity: 0;
  }
`,Vr=t.keyframes`
  from {
    transform: perspective(400px);
  }

  30% {
    transform: perspective(400px) rotate3d(0, 1, 0, -15deg);
    opacity: 1;
  }

  to {
    transform: perspective(400px) rotate3d(0, 1, 0, 90deg);
    opacity: 0;
  }
`;function Br(r,e){switch(e){case"horizontal":return r?Mr:Sr;case"vertical":return r?Vr:Cr;default:return Xr}}var Nr={backfaceVisibility:"visible"},Ma=r=>{let m=r,{direction:e,reverse:a=!1,style:s}=m,i=j(m,["direction","reverse","style"]),o=(0,rt.useMemo)(()=>Br(a,e),[e,a]);return(0,n.jsx)(x,p({keyframes:o,style:Object.assign({},s,Nr)},i))},Dr=t.keyframes`
  0% {
    animation-timing-function: ease-in-out;
  }

  20%,
  60% {
    transform: rotate3d(0, 0, 1, 80deg);
    animation-timing-function: ease-in-out;
  }

  40%,
  80% {
    transform: rotate3d(0, 0, 1, 60deg);
    animation-timing-function: ease-in-out;
    opacity: 1;
  }

  to {
    transform: translate3d(0, 700px, 0);
    opacity: 0;
  }
`,Lr=t.keyframes`
  from {
    opacity: 0;
    transform: scale(0.1) rotate(30deg);
    transform-origin: center bottom;
  }

  50% {
    transform: rotate(-10deg);
  }

  70% {
    transform: rotate(3deg);
  }

  to {
    opacity: 1;
    transform: scale(1);
  }
`,Da=t.keyframes`
  from {
    opacity: 0;
    transform: translate3d(-100%, 0, 0) rotate3d(0, 0, 1, -120deg);
  }

  to {
    opacity: 1;
    transform: translate3d(0, 0, 0);
  }
`,_a=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    opacity: 0;
    transform: translate3d(100%, 0, 0) rotate3d(0, 0, 1, 120deg);
  }
`,_r={transformOrigin:"top left"},Ea=r=>{let s=r,{style:e}=s,a=j(s,["style"]);return(0,n.jsx)(x,p({keyframes:Dr,style:Object.assign({},e,_r)},a))},Fa=r=>(0,n.jsx)(x,p({keyframes:Lr},r));var Er=t.keyframes`
  from {
    transform: rotate3d(0, 0, 1, -200deg);
    opacity: 0;
  }

  to {
    transform: translate3d(0, 0, 0);
    opacity: 1;
  }
`,qr=t.keyframes`
  from {
    transform: rotate3d(0, 0, 1, -45deg);
    opacity: 0;
  }

  to {
    transform: translate3d(0, 0, 0);
    opacity: 1;
  }
`,Fr=t.keyframes`
  from {
    transform: rotate3d(0, 0, 1, 45deg);
    opacity: 0;
  }

  to {
    transform: translate3d(0, 0, 0);
    opacity: 1;
  }
`,Tr=t.keyframes`
  from {
    transform: rotate3d(0, 0, 1, 45deg);
    opacity: 0;
  }

  to {
    transform: translate3d(0, 0, 0);
    opacity: 1;
  }
`,$r=t.keyframes`
  from {
    transform: rotate3d(0, 0, 1, -90deg);
    opacity: 0;
  }

  to {
    transform: translate3d(0, 0, 0);
    opacity: 1;
  }
`,Ar=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    transform: rotate3d(0, 0, 1, 200deg);
    opacity: 0;
  }
`,Pr=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    transform: rotate3d(0, 0, 1, 45deg);
    opacity: 0;
  }
`,Jr=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    transform: rotate3d(0, 0, 1, -45deg);
    opacity: 0;
  }
`,Wr=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    transform: rotate3d(0, 0, 1, -45deg);
    opacity: 0;
  }
`,Hr=t.keyframes`
  from {
    opacity: 1;
  }

  to {
    transform: rotate3d(0, 0, 1, 90deg);
    opacity: 0;
  }
`;function Kr(r,e){switch(e){case"bottom-left":return r?[Pr,{transformOrigin:"left bottom"}]:[qr,{transformOrigin:"left bottom"}];case"bottom-right":return r?[Jr,{transformOrigin:"right bottom"}]:[Fr,{transformOrigin:"right bottom"}];case"top-left":return r?[Wr,{transformOrigin:"left bottom"}]:[Tr,{transformOrigin:"left bottom"}];case"top-right":return r?[Hr,{transformOrigin:"right bottom"}]:[$r,{transformOrigin:"right bottom"}];default:return r?[Ar,{transformOrigin:"center"}]:[Er,{transformOrigin:"center"}]}}var ts=r=>{let f=r,{direction:e,reverse:a=!1,style:s}=f,i=j(f,["direction","reverse","style"]),[o,m]=(0,et.useMemo)(()=>Kr(a,e),[e,a]);return(0,n.jsx)(x,p({keyframes:o,style:Object.assign({},s,m)},i))},Zr=t.keyframes`
  from {
    transform: translate3d(0, -100%, 0);
    visibility: visible;
  }

  to {
    transform: translate3d(0, 0, 0);
  }
`,Gr=t.keyframes`
  from {
    transform: translate3d(-100%, 0, 0);
    visibility: visible;
  }

  to {
    transform: translate3d(0, 0, 0);
  }
`,Qr=t.keyframes`
  from {
    transform: translate3d(100%, 0, 0);
    visibility: visible;
  }

  to {
    transform: translate3d(0, 0, 0);
  }
`,te=t.keyframes`
  from {
    transform: translate3d(0, 100%, 0);
    visibility: visible;
  }

  to {
    transform: translate3d(0, 0, 0);
  }
`,re=t.keyframes`
  from {
    transform: translate3d(0, 0, 0);
  }

  to {
    visibility: hidden;
    transform: translate3d(0, 100%, 0);
  }
`,ee=t.keyframes`
  from {
    transform: translate3d(0, 0, 0);
  }

  to {
    visibility: hidden;
    transform: translate3d(-100%, 0, 0);
  }
`,ae=t.keyframes`
  from {
    transform: translate3d(0, 0, 0);
  }

  to {
    visibility: hidden;
    transform: translate3d(100%, 0, 0);
  }
`,se=t.keyframes`
  from {
    transform: translate3d(0, 0, 0);
  }

  to {
    visibility: hidden;
    transform: translate3d(0, -100%, 0);
  }
`;function oe(r,e){switch(e){case"down":return r?re:Zr;case"right":return r?ae:Qr;case"up":return r?se:te;case"left":default:return r?ee:Gr}}var cs=r=>{let o=r,{direction:e,reverse:a=!1}=o,s=j(o,["direction","reverse"]),i=(0,at.useMemo)(()=>oe(a,e),[e,a]);return(0,n.jsx)(x,p({keyframes:i},s))},ne=t.keyframes`
  from {
    opacity: 0;
    transform: scale3d(0.3, 0.3, 0.3);
  }

  50% {
    opacity: 1;
  }
`,ie=t.keyframes`
  from {
    opacity: 0;
    transform: scale3d(0.1, 0.1, 0.1) translate3d(0, -1000px, 0);
    animation-timing-function: cubic-bezier(0.55, 0.055, 0.675, 0.19);
  }

  60% {
    opacity: 1;
    transform: scale3d(0.475, 0.475, 0.475) translate3d(0, 60px, 0);
    animation-timing-function: cubic-bezier(0.175, 0.885, 0.32, 1);
  }
`,me=t.keyframes`
  from {
    opacity: 0;
    transform: scale3d(0.1, 0.1, 0.1) translate3d(-1000px, 0, 0);
    animation-timing-function: cubic-bezier(0.55, 0.055, 0.675, 0.19);
  }

  60% {
    opacity: 1;
    transform: scale3d(0.475, 0.475, 0.475) translate3d(10px, 0, 0);
    animation-timing-function: cubic-bezier(0.175, 0.885, 0.32, 1);
  }
`,fe=t.keyframes`
  from {
    opacity: 0;
    transform: scale3d(0.1, 0.1, 0.1) translate3d(1000px, 0, 0);
    animation-timing-function: cubic-bezier(0.55, 0.055, 0.675, 0.19);
  }

  60% {
    opacity: 1;
    transform: scale3d(0.475, 0.475, 0.475) translate3d(-10px, 0, 0);
    animation-timing-function: cubic-bezier(0.175, 0.885, 0.32, 1);
  }
`,ce=t.keyframes`
  from {
    opacity: 0;
    transform: scale3d(0.1, 0.1, 0.1) translate3d(0, 1000px, 0);
    animation-timing-function: cubic-bezier(0.55, 0.055, 0.675, 0.19);
  }

  60% {
    opacity: 1;
    transform: scale3d(0.475, 0.475, 0.475) translate3d(0, -60px, 0);
    animation-timing-function: cubic-bezier(0.175, 0.885, 0.32, 1);
  }
`,le=t.keyframes`
  from {
    opacity: 1;
  }

  50% {
    opacity: 0;
    transform: scale3d(0.3, 0.3, 0.3);
  }

  to {
    opacity: 0;
  }
`,pe=t.keyframes`
  40% {
    opacity: 1;
    transform: scale3d(0.475, 0.475, 0.475) translate3d(0, -60px, 0);
    animation-timing-function: cubic-bezier(0.55, 0.055, 0.675, 0.19);
  }

  to {
    opacity: 0;
    transform: scale3d(0.1, 0.1, 0.1) translate3d(0, 2000px, 0);
    animation-timing-function: cubic-bezier(0.175, 0.885, 0.32, 1);
  }
`,de=t.keyframes`
  40% {
    opacity: 1;
    transform: scale3d(0.475, 0.475, 0.475) translate3d(42px, 0, 0);
  }

  to {
    opacity: 0;
    transform: scale(0.1) translate3d(-2000px, 0, 0);
  }
`,ye=t.keyframes`
  40% {
    opacity: 1;
    transform: scale3d(0.475, 0.475, 0.475) translate3d(-42px, 0, 0);
  }

  to {
    opacity: 0;
    transform: scale(0.1) translate3d(2000px, 0, 0);
  }
`,ue=t.keyframes`
  40% {
    opacity: 1;
    transform: scale3d(0.475, 0.475, 0.475) translate3d(0, 60px, 0);
    animation-timing-function: cubic-bezier(0.55, 0.055, 0.675, 0.19);
  }

  to {
    opacity: 0;
    transform: scale3d(0.1, 0.1, 0.1) translate3d(0, -2000px, 0);
    animation-timing-function: cubic-bezier(0.175, 0.885, 0.32, 1);
  }
`;function ge(r,e){switch(e){case"down":return r?pe:ie;case"left":return r?de:me;case"right":return r?ye:fe;case"up":return r?ue:ce;default:return r?le:ne}}var Os=r=>{let o=r,{direction:e,reverse:a=!1}=o,s=j(o,["direction","reverse"]),i=(0,st.useMemo)(()=>ge(a,e),[e,a]);return(0,n.jsx)(x,p({keyframes:i},s))};export{Ge as a,ca as b,Ia as c,Ma as d,Ea as e,Fa as f,ts as g,cs as h,Os as i};
